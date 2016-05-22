using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{

    /// <summary>
    /// 产品类别
    /// </summary>
    public partial class ProductCategory:BaseEntity
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置产品类别标识
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否特色产品
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
