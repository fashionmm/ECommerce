using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Catalog
{
    public enum ProductType
    {
        /// <summary>
        /// 简单
        /// </summary>
        SimpleProduct = 5,
        /// <summary>
        /// 分组（产品的变种）
        /// </summary>
        GroupedProduct = 10,

    }
}
