using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Tasks
{
    /// <summary>
    /// 任务接口，每个任务都必须实现此接口
    /// </summary>
    public partial interface ITask
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        void Execute();
    }
}
