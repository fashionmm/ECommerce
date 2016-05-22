using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
   public enum BackorderMode
    {
        /// <summary>
        /// 不缺货
        /// </summary>
        NoBackorders = 0,
        /// <summary>
        /// 允许数量低于0
        /// </summary>
        AllowQtyBelow0 = 1,
        /// <summary>
        /// 允许数量低于0并通知客户
        /// </summary>
        AllowQtyBelow0AndNotifyCustomer = 2,

    }
}
