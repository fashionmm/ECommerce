using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Orders
{
    /// <summary>
    /// 表示退货状态
    /// </summary>
    public enum ReturnRequestStatus
    {
        /// <summary>
        /// 待定
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 接受
        /// </summary>
        Received = 10,
        /// <summary>
        /// 退货审核
        /// </summary>
        ReturnAuthorized = 20,
        /// <summary>
        /// Item(s) 修理
        /// </summary>
        ItemsRepaired = 30,
        /// <summary>
        /// Item(s) 退回
        /// </summary>
        ItemsRefunded = 40,
        /// <summary>
        /// Request 拒绝
        /// </summary>
        RequestRejected = 50,
        /// <summary>
        /// 取消
        /// </summary>
        Cancelled = 60,
    }

}
