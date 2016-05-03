using System;
using ECommerce.Core.Domain.Customers;

namespace ECommerce.Core.Domain.Logging
{
    /// <summary>
    /// 表示活动日志记录
    /// </summary>
    public partial class ActivityLog : BaseEntity
    {
        /// <summary>
        /// 获取或设置活动日志类型标识符
        /// </summary>
        public int ActivityLogTypeId { get; set; }

        /// <summary>
        /// 获取或设置顾客标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置活动的评论
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 活动日志类型导航属性
        /// </summary>
        public virtual ActivityLogType ActivityLogType { get; set; }

        /// <summary>
        /// 顾客导航属性
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
