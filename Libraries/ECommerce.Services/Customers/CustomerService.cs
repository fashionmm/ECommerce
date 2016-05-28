using ECommerce.Core;
using ECommerce.Core.Caching;
using ECommerce.Core.Data;
using ECommerce.Core.Domain.Customers;
using ECommerce.Core.Domain.Orders;
using ECommerce.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Customers
{
    /// <summary>
    /// 顾客服务接口实现
    /// </summary>
    public partial class CustomerService : ICustomerService
    {
        #region  常量
        /// <summary>
        /// 缓存键
        /// </summary>
        /// <remarks>
        /// {0}:显示隐藏记录？
        /// </remarks>
        private const string CUSTOMERROLES_ALL_KEY = "E.customerrole.all-{0}";

        /// <summary>
        /// 缓存键
        /// </summary>
        /// <remarks>
        /// {0}:系统名称
        /// </remarks>
        private const string CUSTOMERROLES_BY_SYSTEMNAME_KEY = "E.customerrole.systemname-{0}";

        /// <summary>
        /// 模式匹配清除缓存
        /// </summary>
        private const string CUSTOMERROLE_PATTERN_KEY = "E.customerrole.";

        #endregion

        #region 字段
        private readonly IRepository<Customer> _customerRepository;

        private readonly IRepository<CustomerRole> _customerRoleRepostitory;


        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region 构造函数
        public CustomerService(ICacheManager cacheManager,
            IRepository<Customer> customerRepository)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
        }
        #endregion

        #region 顾客

        /// <summary>
        /// 获取所有顾客
        /// </summary>
        /// <param name="createdFromUtc">创建起始日期; 为空加载全部记录</param>
        /// <param name="createdToUtc">创建截止日期; 为空加载全部记录</param>
        /// <param name="affiliateId">从属标识符</param>
        /// <param name="vendorId">供应商标识符</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="email">邮箱; 为空加载全部</param>
        /// <param name="username">用户; 为空加载全部</param>
        /// <param name="firstName">第一名称; 为空加载全部</param>
        /// <param name="lastName">第二名称; 为空加载全部</param>
        /// <param name="dayOfBirth">出生日; 0 加载全部</param>
        /// <param name="monthOfBirth">出生月; 0 加载全部</param>
        /// <param name="company">公司; 为空加载全部</param>
        /// <param name="phone">电话; 为空加载全部</param>
        /// <param name="zipPostalCode">邮编; 为空加载全部</param>
        /// <param name="loadOnlyWithShoppingCart">一个值，指示是否加载顾客，仅有购物车时。</param>
        /// <param name="sct">一个值，标识购物车类型，用于过滤。仅当“loadOnlyWithShoppingCartValue”为真时。 </param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小 默认值为Int32.MaxValue</param>
        /// <returns>顾客分页列表</returns>
        public virtual IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc = null,
             DateTime? createdToUtc = null, int affiliateId = 0, int vendorId = 0,
             int[] customerRoleIds = null, string email = null, string username = null,
             string firstName = null, string lastName = null,
             int dayOfBirth = 0, int monthOfBirth = 0,
             string company = null, string phone = null, string zipPostalCode = null,
             bool loadOnlyWithShoppingCart = false, ShoppingCartType? sct = null,
             int pageIndex = 0, int pageSize = 2147483647)
        {
            var query = _customerRepository.Table;

            if (createdFromUtc.HasValue)
                query = query.Where(c => createdFromUtc.Value <= c.CreatedOnUtc);

            if (createdToUtc.HasValue)
                query = query.Where(c => createdToUtc.Value >= c.CreatedOnUtc);

            if (affiliateId > 0)
                query = query.Where(c => affiliateId == c.AffiliateId);

            if (vendorId > 0)
                query = query.Where(c => vendorId == c.VendorId);

            //过滤，已删除
            query = query.Where(c => !c.Deleted);

            if (customerRoleIds != null && customerRoleIds.Length > 0)
                query = query.Where(c => c.CustomerRoles.Select(cr => cr.Id).Intersect(customerRoleIds).Any());


            if (!String.IsNullOrWhiteSpace(email))
                query = query.Where(c => c.Email.Contains(email));

            if (!String.IsNullOrWhiteSpace(username))
                query = query.Where(c => c.UserName.Contains(username));

            if (!String.IsNullOrWhiteSpace(firstName))
            {

            }

            if (loadOnlyWithShoppingCart)
            {
                int? sctId = null;
                if (sct.HasValue)
                    sctId = (int)sct.Value;

                query = sct.HasValue ?
                    query.Where(c => c.ShoppingCartItems.Any(x => x.ShoppingCartTypeId == sctId)) :
                    query.Where(c => c.ShoppingCartItems.Any());
            }
            //排序
            query.OrderByDescending(c => c.CreatedOnUtc);

            var customers = new PagedList<Customer>(query, pageIndex, pageSize);
            return customers;
        }

        /// <summary>
        /// 根据顾客格式，获取所有顾客。（包含被删除的）Gets all customers by customer format (including deleted ones)
        /// </summary>
        /// <param name="passwordFormat">密码格式</param>
        /// <returns>顾客列表</returns>
        public virtual IList<Customer> GetAllCustomersByPasswordFormat(PasswordFormat passwordFormat)
        {
            var passwordFormatId = (int)passwordFormat;

            var query = _customerRepository.Table;
            query = query.Where(c => c.PasswordFormatId == passwordFormatId);

            query = query.OrderByDescending(c => c.CreatedOnUtc);

            var customers = query.ToList();
            return customers;
        }

        /// <summary>
        ///获取在线顾客
        /// </summary>
        /// <param name="lastActivityFromUtc">顾客近期活动开始日期。</param>
        /// <param name="customerRoleIds">顾客角色标识数组（最近匹配）用于过滤。Null 或 空数组，加载全部。</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>顾客分页列表</returns>
        public virtual IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
              int[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return null;
        }

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <param name="customer">顾客</param>
        public virtual void DeleteCustomer(Customer customer)
        {

        }

        /// <summary>
        /// 获取顾客
        /// </summary>
        /// <param name="customerId">顾客标识</param>
        /// <returns>A customer</returns>
        public virtual Customer GetCustomerById(int customerId)
        {
            return null;
        }

        /// <summary>
        /// 根据顾客标识数组，获取顾客列表
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        public virtual IList<Customer> GetCustomersByIds(int[] customerIds)
        {
            return null;
        }

        /// <summary>
        ///根据Guid，获取顾客对象
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        public virtual Customer GetCustomerByGuid(Guid customerGuid)
        {
            return null;
        }

        /// <summary>
        /// 根据邮箱，获取顾客对象
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>顾客</returns>
        public virtual Customer GetCustomerByEmail(string email)
        {
            return null;
        }

        /// <summary>
        /// 根据系统名称，获取顾客对象
        /// </summary>
        /// <param name="systemName">系统名称</param>
        /// <returns>顾客</returns>
        public virtual Customer GetCustomerBySystemName(string systemName)
        {
            return null;
        }

        /// <summary>
        /// 根据用户名，获取顾客对象
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>顾客</returns>
        public virtual Customer GetCustomerByUsername(string username)
        {
            return null;
        }

        /// <summary>
        /// 添加来宾顾客
        /// </summary>
        /// <returns>顾客</returns>
        public virtual Customer InsertGuestCustomer()
        {
            return null;
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="customer">顾客</param>
        public virtual void InsertCustomer(Customer customer)
        {

        }

        /// <summary>
        /// 更新顾客
        /// </summary>
        /// <param name="customer">顾客</param>
        public virtual void UpdateCustomer(Customer customer)
        {

        }

        /// <summary>
        /// 重置数据所需的检验
        /// </summary>
        /// <param name="customer">顾客</param>
        /// <param name="storeId">店铺标识</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        /// <param name="clearCheckoutAttributes">A value indicating whether to clear selected checkout attributes</param>
        /// <param name="clearRewardPoints">A value indicating whether to clear "Use reward points" flag</param>
        /// <param name="clearShippingMethod">A value indicating whether to clear selected shipping method</param>
        /// <param name="clearPaymentMethod">A value indicating whether to clear selected payment method</param>
        public virtual void ResetCheckoutData(Customer customer, int storeId,
              bool clearCouponCodes = false, bool clearCheckoutAttributes = false,
              bool clearRewardPoints = true, bool clearShippingMethod = true,
              bool clearPaymentMethod = true)
        {

        }

        /// <summary>
        /// 删除来宾顾客记录
        /// </summary>
        /// <param name="createdFromUtc">创建起始日期;为空装载所有记录</param>
        /// <param name="createdToUtc">创建截止日期; 为空装载所有记录</param>
        /// <param name="onlyWithoutShoppingCart">一个值，指示是否删除顾客，当没有购物车时</param>
        /// <returns>删除顾客记录数</returns>
        public virtual int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            return 0;
        }

        #endregion

        #region 顾客角色

        /// <summary>
        /// 删除顾客角色
        /// </summary>
        /// <param name="customerRole">顾客角色</param>
        public virtual void DeleteCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            if (customerRole.IsSystemRole)
                throw new NopException("系统角色不能被删除");

            _customerRoleRepostitory.Delete(customerRole);

            _cacheManager.RemoveByPattern(CUSTOMERROLE_PATTERN_KEY);

            //事件通知
            _eventPublisher.EntityDeleted(customerRole);
        }

        /// <summary>
        /// 根据顾客角色标识，获取顾客角色
        /// </summary>
        /// <param name="customerRoleId">顾客角色标识</param>
        /// <returns>顾客角色</returns>
        public virtual CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            if (customerRoleId == 0)
                return null;
            return _customerRoleRepostitory.GetById(customerRoleId);
        }

        /// <summary>
        /// 根据顾客角色系统名称，获取一个顾客角色
        /// </summary>
        /// <param name="systemName">顾客角色系统名称</param>
        /// <returns>顾客角色</returns>
        public virtual CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            if (String.IsNullOrWhiteSpace(systemName))
                return null;

            string key = string.Format(CUSTOMERROLES_BY_SYSTEMNAME_KEY, systemName);

            return _cacheManager.Get(key, () =>
            {

                var query = from cr in _customerRoleRepostitory.Table
                            where cr.SystemName == systemName
                            orderby cr.Id
                            select cr;

                var customerRoles = query.FirstOrDefault();

                return customerRoles;
            });
        }

        /// <summary>
        /// 获取所有顾客角色
        /// </summary>
        /// <param name="showHidden">是否显示隐藏记录</param>
        /// <returns>顾客角色列表</returns>
        public virtual IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            string key = string.Format(CUSTOMERROLES_ALL_KEY, showHidden);

            //获取顾客角色，并缓存，同时返回记录。
            return _cacheManager.Get(key, () =>
            {
                //var query = _customerRoleRepostitory.Table
                //    .Where(r => showHidden || r.Active)
                //    .OrderBy(r => r.Name);

                var query = from cr in _customerRoleRepostitory.Table
                            where (showHidden || cr.Active)
                            orderby cr.Name
                            select cr;

                var customerRoles = query.ToList();

                return customerRoles;
            });

        }

        /// <summary>
        /// 添加顾客角色
        /// </summary>
        /// <param name="customerRole">顾客角色对象</param>
        public virtual void InsertCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            _customerRoleRepostitory.Insert(customerRole);

            _cacheManager.RemoveByPattern(CUSTOMERROLE_PATTERN_KEY);
        }

        /// <summary>
        ///更新顾客角色
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual void UpdateCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            _customerRoleRepostitory.Update(customerRole);

            _cacheManager.RemoveByPattern(CUSTOMERROLE_PATTERN_KEY);

            //事件通知
            _eventPublisher.EntityUpdated(customerRole);
        }

        #endregion


    }
}
