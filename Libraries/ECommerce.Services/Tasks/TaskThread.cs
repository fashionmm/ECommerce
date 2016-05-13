using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;


namespace ECommerce.Services.Tasks
{
    /// <summary>
    /// 任务进程
    /// </summary>
    public partial class TaskThread : IDisposable
    {
        private Timer _timer;
        private bool _disposed;
        private readonly Dictionary<string, Task> _tasks;

        internal TaskThread()
        {
            this._tasks = new Dictionary<string, Task>();
            this.Seconds = 10 * 60;

        }

        private void Run()
        {
            if (Seconds <= 0)
                return;

            this.StartedUtc = DateTime.UtcNow;
            this.IsRunning = true;
            foreach (Task task in this._tasks.Values)
            {
                task.Execute();
            }
            this.IsRunning = false;
        }

        private void TimerHandler(object state)
        {
            this._timer.Change(-1, 1);
            this.Run();
            if (this.RunOnlyOnce)
            {
                this.Dispose();
            }
            else
            {
                this._timer.Change(this.Interval,this.Interval);
            }
        }

       
        #region 接口实现
        public void Dispose()
        {
            if ((this._timer != null) && !this._disposed)
            {
                lock(this){
                    this._timer.Dispose();
                    this._timer = null;
                    this._disposed = true;
                }
            }
        }
        #endregion

        #region 
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitTimer()
        {
            if (this._timer == null)
            {
                this._timer = new Timer(new TimerCallback(this.TimerHandler),null,this.Interval,this.Interval);
            }
        }

        /// <summary>
        /// 添加一个任务到线程
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            if (!this._tasks.ContainsKey(task.Name))
            {
                this._tasks.Add(task.Name, task);
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置运行任务的时间间隔，在几秒钟内以。
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 获取或设置任务进程开始时间
        /// </summary>
        public DateTime StartedUtc { get; private set; }

        /// <summary>
        /// 获取或设置一个值，表示进程是否运行
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public IList<Task> Tasks
        {
            get
            {
                var list = new List<Task>();
                foreach (var task in this._tasks.Values)
                {
                    list.Add(task);
                }
                return new ReadOnlyCollection<Task>(list);
            }
        }

        /// <summary>
        /// 获取执行任务的时间间隔
        /// </summary>
        public int Interval
        {
            get
            {
                return this.Seconds * 1000;
            }
        }

        /// <summary>
        /// 获取或设置一个值指示线程是否应该只运行一次（每应用程序启动）
        /// </summary>
        public bool RunOnlyOnce { get; set; }

        #endregion
    }
}
