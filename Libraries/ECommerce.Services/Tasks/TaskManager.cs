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
        private static readonly TaskManager _taskManager=new TaskManager();

        private readonly List<TaskThread> _taskThreads = new List<TaskThread>();

        private const int _notRunTasksInterval = 60 * 30; //30分钟
        private TaskManager()
        {

        }

        public void Initialize()
        {
            this._taskThreads.Clear();
            
           
          
        }

        /// <summary>
        /// 启动任务管理器
        /// </summary>
        public void Start()
        {
            foreach (var taskThread in this._taskThreads)
            {
              //  taskThread.InitTimer();
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
