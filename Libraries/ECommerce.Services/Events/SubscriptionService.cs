using ECommerce.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Events
{
    /// <summary>
    /// 事件订阅服务实现
    /// </summary>
    public  class SubscriptionService : ISubscriptionService
    {

        /// <summary>
        /// 获取订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<IConsumer<T>> GetSubscriptions<T>()
        {
            return EngineContext.Current.ResolveAll<IConsumer<T>>();
        }
    }
}
