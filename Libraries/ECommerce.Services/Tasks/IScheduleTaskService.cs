using ECommerce.Core.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Services.Tasks
{
    /// <summary>
    /// 任务服务接口
    /// </summary>
   public partial interface  IScheduleTaskService
    {
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="task">Task</param>
        void DeleteTask(ScheduleTask task);

        /// <summary>
        ///根据Id获取一个任务
        /// </summary>
        /// <param name="taskId">Task identifier</param>
        /// <returns>Task</returns>
        ScheduleTask GetTaskById(int taskId);

        /// <summary>
        /// 根据类型获取一个任务
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        ScheduleTask GetTaskByType(string type);

        /// <summary>
        /// 获取所有任务
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Tasks</returns>
        IList<ScheduleTask> GetAllTasks(bool showHidden = false);

        /// <summary>
        /// 添加一个任务
        /// </summary>
        /// <param name="task">Task</param>
        void InsertTask(ScheduleTask task);

        /// <summary>
        /// 更新一个任务
        /// </summary>
        /// <param name="task">Task</param>
        void UpdateTask(ScheduleTask task);
    }
}
