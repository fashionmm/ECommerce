using System;
using ECommerce.Core.Domain.Customers;

namespace ECommerce.Core.Domain.Logging
{
    /// <summary>
    /// 表示日志记录
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// 获取或设置日志级别标识符
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// 获取或设置简讯
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// 获取或设置完整异常
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// 获取或设置IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 获取或设置顾客标识符
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 获取或设置页面的URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// 获取或设置引用网址
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置日志级别
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// 顾客导航属性
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
