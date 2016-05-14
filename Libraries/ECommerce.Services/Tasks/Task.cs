using Autofac;
using ECommerce.Core.Configuration;
using ECommerce.Core.Domain.Tasks;
using ECommerce.Core.Infrastructure;
using ECommerce.Services.Infrastructure;
using ECommerce.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Services.Tasks
{
    public partial class Task
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private Task()
        {
            this.Enabled = true;
        }

        public Task(ScheduleTask task)
        {
            this.Type = task.Type;
            this.Enabled = task.Enabled;
            this.StopOnError = task.StopOnError;
            this.Name = task.Name;

        }

        #region 工具方法

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private ITask CreateTask(ILifetimeScope scope)
        {
            ITask task = null;
            if (this.Enabled)
            {
                var type2 = System.Type.GetType(this.Type);
                if (type2 != null)
                {
                    object instance;
                    if (!EngineContext.Current.ContainerManager.TryResolve(type2, scope, out instance))
                    {
                        //
                        instance = EngineContext.Current.ContainerManager.ResolveUnregistered(type2, scope);
                    }
                    task = instance as ITask;
                }
            }
            return task;
        }

        #endregion

        #region 方法
        public void Execute(bool throwException = false, bool dispose = true, bool ensureRunOnOneWebFarmInstance = true)
        {

            //
            var scope = EngineContext.Current.ContainerManager.Scope();
            var scheduleTaskService = EngineContext.Current.ContainerManager.Resolve<IScheduleTaskService>("", scope);
            var scheduleTask = scheduleTaskService.GetTaskByType(this.Type);
            try
            {
                //任务是在一个时间节点运行吗？
                if (ensureRunOnOneWebFarmInstance)
                {
                    var eConfig = EngineContext.Current.ContainerManager.Resolve<EConfig>("", scope);
                    if (eConfig.MultipleInstancesEnabled)
                    {
                        var machineNameProvider = EngineContext.Current.ContainerManager.Resolve<IMachineNameProvider>("", scope);
                        var machineName = machineNameProvider.GetMachineName();
                        if (String.IsNullOrEmpty(machineName))
                        {
                            throw new Exception("Machine name cannot be detected. You cannot run in web farm.");
                            //其实在这种情况下，我们可以产生一些独特的字符串（例如GUID）并将其存储在一些“静态”（！！！）变量
                            //可作为一个机器名
                        }
                        //
                        if (scheduleTask.LeasedUntilUtc.HasValue &&
                            scheduleTask.LeasedUntilUtc.Value >= DateTime.UtcNow &&
                            scheduleTask.LeasedByMachineName != machineName)
                            return;

                        //
                        scheduleTask.LeasedByMachineName = machineName;
                        scheduleTask.LeasedUntilUtc = DateTime.UtcNow.AddMinutes(30);
                        scheduleTaskService.UpdateTask(scheduleTask);
                    }
                }

                //初始化并执行
                var task = this.CreateTask(scope);
                if (task != null)
                {
                    this.LastStartUtc = DateTime.UtcNow;
                    if (scheduleTask != null)
                    {
                        //
                        scheduleTask.LastStartUtc = this.LastStartUtc;
                        scheduleTaskService.UpdateTask(scheduleTask);
                    }
                    task.Execute();
                    this.LastEndUtc = this.LastSuccessUtc = DateTime.UtcNow;
                }
            }
            catch (Exception exc)
            {
                this.Enabled = !this.StopOnError;
                this.LastEndUtc = DateTime.UtcNow;

                //错误日志
                var logger = EngineContext.Current.ContainerManager.Resolve<ILogger>("", scope);
                logger.Error(string.Format("运行 '{0}' 计划任务发生错误 . {1}", this.Name, exc.Message), exc);
                if (throwException)
                    throw;
            }

            if (scheduleTask != null)
            {
                //
                scheduleTask.LastEndUtc = this.LastEndUtc;
                scheduleTask.LastSuccessUtc = this.LastSuccessUtc;
                scheduleTaskService.UpdateTask(scheduleTask);
            }

            //释放所有资源
            if (dispose)
            {
                scope.Dispose();
            }

        }
        #endregion

        #region 属性

        /// <summary>
        /// 最近一次开始时间
        /// </summary>
        public DateTime? LastStartUtc { get; private set; }

        /// <summary>
        /// 最近一次完成时间
        /// </summary>
        public DateTime? LastEndUtc { get; private set; }

        /// <summary>
        /// 最近一次成功时间
        /// </summary>
        public DateTime? LastSuccessUtc { get; private set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// 发生错误是否停止任务
        /// </summary>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 任务是否启动
        /// </summary>
        public bool Enabled { get; set; }

        #endregion
    }
}
