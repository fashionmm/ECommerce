using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 产品制造商映射
    /// （多对多，分解成一对多）
    /// </summary>
    public partial class ProductManufacturer : BaseEntity
    {
        /// <summary>
        /// 获取或设置商品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置制造商标识
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否具有特色
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        #region 导航
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Product Product { get; set; }

        #endregion
    }
}
