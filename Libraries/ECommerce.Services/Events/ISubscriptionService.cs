using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Events
{
    /// <summary>
    /// 事件订阅
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// 获取订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>事件消费者</returns>
        IList<IConsumer<T>> GetSubscriptions<T>();
    }
}
