using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TierPrice : BaseEntity
    {
        /// <summary>
        /// 获取或设置商品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置店铺标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置顾客角色标识
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置价格
        /// </summary>
        public decimal Price { get; set; }

        #region 导航
        public virtual Product Product { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }

        #endregion
    }
}
