using ECommerce.Core;
using ECommerce.Core.Domain.Customers;
using ECommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Customers
{
    /// <summary>
    /// 顾客服务接口
    /// </summary>
    public partial interface ICustomerService
    {
        #region 顾客

        /// <summary>
        /// 获取所有顾客
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="affiliateId">Affiliate identifier</param>
        /// <param name="vendorId">Vendor identifier</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="email">Email; null to load all customers</param>
        /// <param name="username">Username; null to load all customers</param>
        /// <param name="firstName">First name; null to load all customers</param>
        /// <param name="lastName">Last name; null to load all customers</param>
        /// <param name="dayOfBirth">Day of birth; 0 to load all customers</param>
        /// <param name="monthOfBirth">Month of birth; 0 to load all customers</param>
        /// <param name="company">Company; null to load all customers</param>
        /// <param name="phone">Phone; null to load all customers</param>
        /// <param name="zipPostalCode">Phone; null to load all customers</param>
        /// <param name="loadOnlyWithShoppingCart">Value indicating whether to load customers only with shopping cart</param>
        /// <param name="sct">Value indicating what shopping cart type to filter; userd when 'loadOnlyWithShoppingCart' param is 'true'</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc = null,
            DateTime? createdToUtc = null, int affiliateId = 0, int vendorId = 0,
            int[] customerRoleIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            int dayOfBirth = 0, int monthOfBirth = 0,
            string company = null, string phone = null, string zipPostalCode = null,
            bool loadOnlyWithShoppingCart = false, ShoppingCartType? sct = null,
            int pageIndex = 0, int pageSize = 2147483647); //Int32.MaxValue

        /// <summary>
        /// Gets all customers by customer format (including deleted ones)
        /// </summary>
        /// <param name="passwordFormat">Password format</param>
        /// <returns>Customers</returns>
        IList<Customer> GetAllCustomersByPasswordFormat(PasswordFormat passwordFormat);

        /// <summary>
        ///获取在线顾客
        /// </summary>
        /// <param name="lastActivityFromUtc">Customer last activity date (from)</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
            int[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <param name="customer">顾客</param>
        void DeleteCustomer(Customer customer);

        /// <summary>
        /// 获取顾客
        /// </summary>
        /// <param name="customerId">顾客标识</param>
        /// <returns>A customer</returns>
        Customer GetCustomerById(int customerId);

        /// <summary>
        /// 根据顾客标识数组，获取顾客列表
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        IList<Customer> GetCustomersByIds(int[] customerIds);

        /// <summary>
        ///根据Guid，获取顾客对象
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        Customer GetCustomerByGuid(Guid customerGuid);

        /// <summary>
        /// 根据邮箱，获取顾客对象
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Customer</returns>
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// 根据系统名称，获取顾客对象
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Customer</returns>
        Customer GetCustomerBySystemName(string systemName);

        /// <summary>
        /// 根据用户名，获取顾客对象
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Customer</returns>
        Customer GetCustomerByUsername(string username);

        /// <summary>
        /// 添加来宾顾客
        /// </summary>
        /// <returns>Customer</returns>
        Customer InsertGuestCustomer();

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="customer">Customer</param>
        void InsertCustomer(Customer customer);

        /// <summary>
        /// 更新顾客
        /// </summary>
        /// <param name="customer">Customer</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// 重置数据所需的检验
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        /// <param name="clearCheckoutAttributes">A value indicating whether to clear selected checkout attributes</param>
        /// <param name="clearRewardPoints">A value indicating whether to clear "Use reward points" flag</param>
        /// <param name="clearShippingMethod">A value indicating whether to clear selected shipping method</param>
        /// <param name="clearPaymentMethod">A value indicating whether to clear selected payment method</param>
        void ResetCheckoutData(Customer customer, int storeId,
            bool clearCouponCodes = false, bool clearCheckoutAttributes = false,
            bool clearRewardPoints = true, bool clearShippingMethod = true,
            bool clearPaymentMethod = true);

        /// <summary>
        /// 删除来宾顾客记录
        /// </summary>
        /// <param name="createdFromUtc">创建起始日期;为空装载所有记录</param>
        /// <param name="createdToUtc">创建截止日期; 为空装载所有记录</param>
        /// <param name="onlyWithoutShoppingCart">一个值，指示是否删除顾客，当没有购物车时</param>
        /// <returns>删除顾客记录数</returns>
        int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart);

        #endregion

        #region 顾客角色

        /// <summary>
        /// 删除顾客角色
        /// </summary>
        /// <param name="customerRole">顾客角色</param>
        void DeleteCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// 根据顾客角色标识，获取顾客角色
        /// </summary>
        /// <param name="customerRoleId">顾客角色标识</param>
        /// <returns>顾客角色</returns>
        CustomerRole GetCustomerRoleById(int customerRoleId);

        /// <summary>
        /// 根据顾客角色系统名称，获取一个顾客角色
        /// </summary>
        /// <param name="systemName">顾客角色系统名称</param>
        /// <returns>顾客角色</returns>
        CustomerRole GetCustomerRoleBySystemName(string systemName);

        /// <summary>
        /// 获取所有顾客角色
        /// </summary>
        /// <param name="showHidden">是否显示隐藏记录</param>
        /// <returns>顾客角色列表</returns>
        IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false);

        /// <summary>
        /// 添加顾客角色
        /// </summary>
        /// <param name="customerRole">顾客角色对象</param>
        void InsertCustomerRole(CustomerRole customerRole);

        /// <summary>
        ///更新顾客角色
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        void UpdateCustomerRole(CustomerRole customerRole);

        #endregion
    }

}
