using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Tasks
{
    /// <summary>
    /// 计划任务
    /// </summary>
    public partial class ScheduleTask : BaseEntity
    {
        /// <summary>
        /// 获取或设置计划名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置运行期（秒）
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        ///获取或设置适合ITask接口的类型。 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用任务
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应在某些错误中停止任务
        /// </summary>
        public bool StopOnError { get; set; }


        /// <summary>
        /// 获取或设置租用此任务的机器名称（实例）。它的使用时，在网络上运行（确保在一台机器上运行的任务）。没有在网络上运行时，它可能是空的。
        /// </summary>
        public string LeasedByMachineName { get; set; }
        /// <summary>
        /// Gets or sets the datetime until the task is leased by some machine (instance). It's used when running in web farm (ensure that a task in run only on one machine).
        /// </summary>
        public DateTime? LeasedUntilUtc { get; set; }

        /// <summary>
        /// 获取或设置最后一次开始的日期时间
        /// </summary>
        public DateTime? LastStartUtc { get; set; }
        /// <summary>
        /// 获取或设置最后一次完成日期时间。（无论成功或失败）
        /// </summary>
        public DateTime? LastEndUtc { get; set; }
        /// <summary>
        /// 获取或设置最后一次成功完成的日期时间。
        /// </summary>
        public DateTime? LastSuccessUtc { get; set; }
    }
}
