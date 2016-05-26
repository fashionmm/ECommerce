using ECommerce.Core.Domain.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 管理每个仓库产品库存记录类
    /// </summary>
    public partial class ProductWarehouseInventory : BaseEntity
    {
        /// <summary>
        /// 获取或设置商品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置仓库标识
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        ///获取或设置库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 获取或设置保留数量（订购但尚未发运）
        /// </summary>
        public int ReservedQuantity { get; set; }

        #region 导航
        /// <summary>
        /// 获取产品对象
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取仓库对象
        /// </summary>
        public virtual Warehouse Warehouse { get; set; }

        #endregion
    }
}
