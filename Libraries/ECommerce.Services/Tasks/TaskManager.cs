using ECommerce.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Tasks
{
    public partial class TaskManager
    {
        private static readonly TaskManager _taskManager = new TaskManager();

        private readonly List<TaskThread> _taskThreads = new List<TaskThread>();

        private const int _notRunTasksInterval = 60 * 30; //30分钟
        private TaskManager()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            this._taskThreads.Clear();
            var taskService = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTasks = taskService
                .GetAllTasks()
                .OrderBy(s => s.Seconds)
                .ToList();

            //分组
            foreach (var scheduleTaskGrouped in scheduleTasks.GroupBy(s => s.Seconds))
            {
                //创建一个进程
                var taskThread = new TaskThread
                {
                    Seconds = scheduleTaskGrouped.Key
                };

                foreach (var scheduleTask in scheduleTaskGrouped)
                {
                    var task = new Task(scheduleTask);
                    taskThread.AddTask(task);
                }
                this._taskThreads.Add(taskThread);
            }

            var notRunTasks = scheduleTasks
                .Where(s => s.Seconds >= _notRunTasksInterval)
                .Where(s => !s.LastStartUtc.HasValue || s.LastStartUtc.Value.AddSeconds(s.Seconds) < DateTime.UtcNow)
                .ToList();

            //创建一个长时间未运行任务线程
            if (notRunTasks.Count > 0)
            {
                var taskThread = new TaskThread
                {
                    RunOnlyOnce = true,
                    Seconds = 60 * 5//应用程序启动后5分钟内运行这样的任务
                };
                foreach (var scheduleTask in notRunTasks)
                {
                    var task = new Task(scheduleTask);
                    taskThread.AddTask(task);
                }
                this._taskThreads.Add(taskThread);
            }
        }

        /// <summary>
        /// 启动任务管理器
        /// </summary>
        public void Start()
        {
            foreach (var taskThread in this._taskThreads)
            {
                taskThread.InitTimer();
            }

        }

        /// <summary>
        /// 停止任务管理者
        /// </summary>
        public void Stop()
        {
            foreach (var taskThread in this._taskThreads)
            {
                taskThread.Dispose();
            }
        }
        /// <summary>
        /// 获取任务管理器实例。单例模式。
        /// </summary>
        public static TaskManager Instance
        {
            get
            {
                return _taskManager;
            }
        }

        /// <summary>
        /// 获取任务管理器中的任务进程。
        /// </summary>
        public IList<TaskThread> TaskThreads
        {
            get
            {
                return new ReadOnlyCollection<TaskThread>(this._taskThreads);
            }
        }
    }
}
