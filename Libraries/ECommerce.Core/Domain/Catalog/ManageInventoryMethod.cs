using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 库存管理方法
    /// </summary>
    public enum ManageInventoryMethod
    {
        /// <summary>
        ///不要跟踪库存产品
        /// </summary>
        DontManageStock = 0,
        /// <summary>
        /// 跟踪库存产品
        /// </summary>
        ManageStock = 1,
        /// <summary>
        /// 通过产品属性跟踪库存
        /// </summary>
        ManageStockByAttributes = 2,

    }
}
