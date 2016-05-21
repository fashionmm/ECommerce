using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Customers
{
    /// <summary>
    /// 顾客身份认证记录类。顾客对象扩展
    /// </summary>
    public partial class ExternalAuthenticationRecord : BaseEntity
    {
        /// <summary>
        /// 获取或设置顾客标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置扩展邮箱
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// 获取或设置OAuth令牌
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// 获取或设置OAuth Access令牌
        /// </summary>
        public string OAuthAccessToken { get; set; }

        /// <summary>
        /// 获取或设置提供者
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
