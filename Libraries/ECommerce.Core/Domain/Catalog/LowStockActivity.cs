using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 低库存活动
    /// </summary>
   public enum LowStockActivity
    {

        /// <summary>
        /// Nothing
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// 禁用购买按钮
        /// </summary>
        DisableBuyButton = 1,
        /// <summary>
        /// 取消发布
        /// </summary>
        Unpublish = 2,

    }
}
