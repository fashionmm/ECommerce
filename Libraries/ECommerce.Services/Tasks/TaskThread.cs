using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce.Services.Tasks
{
    /// <summary>
    /// 任务进程
    /// </summary>
   public partial class TaskThread:IDisposable
    {
       private Timer _timer;
       private bool _disposed;
       private readonly Dictionary<string, Task> _tasks;

       internal TaskThread()
       {
           this._tasks = new Dictionary<string, Task>();
           
       }

       #region 接口实现
       public void Dispose()
       {
           throw new NotImplementedException();
       }
       #endregion
    }
}
