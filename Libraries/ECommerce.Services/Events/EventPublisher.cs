using ECommerce.Core.Infrastructure;
using ECommerce.Core.Plugins;
using ECommerce.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ISubscriptionService _subscriptionService;

        public EventPublisher(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// 发布给消费者
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="x">消费者</param>
        /// <param name="eventMessage"></param>
        public virtual void PublishToConsumer<T>(IConsumer<T> x, T eventMessage)
        {
            //忽略未安装的插件
            var plugin = FindPlugin(x.GetType());
            if (plugin != null && !plugin.Installed)
                return;

            try
            {
                x.HandleEvent(eventMessage);
            }
            catch (Exception exc)
            {
                //记录错误日志
                var logger = EngineContext.Current.Resolve<ILogger>();

                //异常嵌套，防止可能循环错误发生
                try
                {
                    logger.Error(exc.Message, exc);
                }
                catch (Exception)
                {


                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventMessage"></param>
        public virtual void Publish<T>(T eventMessage)
        {
          
           var subscriptions = _subscriptionService.GetSubscriptions<T>();

           subscriptions.ToList().ForEach(x=>PublishToConsumer(x,eventMessage));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        protected virtual PluginDescriptor FindPlugin(Type providerType)
        {
            if (providerType == null)
                throw new ArgumentNullException("providerType");

            if (PluginManager.ReferencedPlugins == null)
                return null;

            foreach (var plugin in PluginManager.ReferencedPlugins)
            {
                if (plugin.ReferencedAssembly == null)
                    continue;
                if (plugin.ReferencedAssembly.FullName == providerType.Assembly.FullName)
                    return plugin;
            }

            return null;
        }
    }
}
