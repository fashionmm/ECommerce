using Autofac;
using ECommerce.Core.Configuration;
using ECommerce.Core.Domain.Tasks;
using ECommerce.Core.Infrastructure;
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
           if(this.Enabled)
           {
               var type2 = System.Type.GetType(this.Type);
               if (type2 != null)
               {
                   object instance;
                   if (!EngineContext.Current.ContainerManager.TryResolve(type2, scope, out instance))
                   {
                       //
                       instance = EngineContext.Current.ContainerManager.ResolveUnregistered(type2,scope);
                   }
                   task = instance as ITask;
               }
           }
           return task;
       }
      
        #endregion

       #region 方法
       public void Execute(bool throwException=false,bool dispose=true,bool ensureRunOnOneWebFarmInstance=true)
       {
           var scope = EngineContext.Current.ContainerManager.Scope();
           var scheduleTaskService = EngineContext.Current.ContainerManager.Resolve<IScheduleTaskService>("",scope);
           var scheduleTask = scheduleTaskService.GetTaskByType(this.Type);
           try
           {
               //任务是在一个时间节点运行吗？
               if (ensureRunOnOneWebFarmInstance)
               {
                   var eConfig=EngineContext.Current.ContainerManager.Resolve<NopConfig>("",scope);
                   if (eConfig.MultipleInstancesEnabled)
                   {

                   }
               }
           }
           catch (Exception)
           {
               
               throw;
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
