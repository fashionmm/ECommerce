using ECommerce.Core.Domain.Common;
using ECommerce.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECommerce.Core.Domain.Customers
{
    /// <summary>
    /// 表示顾客
    /// </summary>
    public partial class Customer:BaseEntity
    {
        private ICollection<ExternalAuthenticationRecord> _externalAuthenticationRecords;
        private ICollection<CustomerRole> _customerRoles;
        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<ReturnRequest> _returnRequests;
        private ICollection<Address> _addresses;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// 获取或设置顾客Guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// 获取或者设置顾客名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 获取或者设置顾客EMail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///获取或者设置顾客账户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或者设置顾客密码格式
        /// </summary>
        public int PasswordFormatId { get; set; }
        /// <summary>
        /// 获取或设置密码格式
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }
        /// <summary>
        /// Gets or sets the password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示顾客是否免税
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// 获取或设置从属标识符
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// 获取或设置用户标识符与该顾客相关的（maganer）
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该客户是否在购物车中有一些产品
        /// <remarks>The same as if we run this.ShoppingCartItems.Count > 0
        /// 我们使用此属性的性能优化：
        /// 如果此属性设置为false，那么我们不需要加载“shoppingcartitems”为每个页面加载导航属性
        /// 它只用于在表现层一些地方
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示用户是否为启用
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否已删除该客户
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户帐户是否系统
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// 获取或设置顾客系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置最后的IP地址
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置上次登录的日期和时间
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// 获取或设置上次活动的日期和时间
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        #region Navigation properties

        /// <summary>
        /// 获取或设置客户生成内容
        /// </summary>
        public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecords
        {
            get { return _externalAuthenticationRecords ?? (_externalAuthenticationRecords = new List<ExternalAuthenticationRecord>()); }
            protected set { _externalAuthenticationRecords = value; }
        }

        /// <summary>
        /// 获取或设置客户角色
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }

        /// <summary>
        /// 获取或设置的购物车中的商品
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>()); }
            protected set { _shoppingCartItems = value; }
        }

        /// <summary>
        /// 获取或设置此客户退货请求
        /// </summary>
        public virtual ICollection<ReturnRequest> ReturnRequests
        {
            get { return _returnRequests ?? (_returnRequests = new List<ReturnRequest>()); }
            protected set { _returnRequests = value; }
        }

        /// <summary>
        /// 默认的帐单地址
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// 默认送货地址
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// 获取或设置顾客地址
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }
        }

        #endregion

    }
}
