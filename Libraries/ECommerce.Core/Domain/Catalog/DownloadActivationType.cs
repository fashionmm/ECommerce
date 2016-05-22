using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 下载激活类型
    /// </summary>
   public enum DownloadActivationType
    {
        /// <summary>
        ///当订单支付时
        /// </summary>
        WhenOrderIsPaid = 1,
        /// <summary>
        /// 手动
        /// </summary>
        Manually = 10,

    }
}
