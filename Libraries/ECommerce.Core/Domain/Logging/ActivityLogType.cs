namespace ECommerce.Core.Domain.Logging
{
    /// <summary>
    /// 表示活动日志类型记录
    /// </summary>
    public partial class ActivityLogType : BaseEntity
    {
        /// <summary>
        /// 获取或设置系统关键字
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// 获取或设置显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用活动日志类型
        /// </summary>
        public bool Enabled { get; set; }
    }
}
