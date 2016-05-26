using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Security
{
    /// <summary>
    /// 支持ACL实体接口。（实现此接口实体，支持ACL）
    /// </summary>
    public interface IAclSupported
    {
        /// <summary>
        /// 获取或设置一个值，指示是否实体支持ACL
        /// </summary>
        bool SubjectToAcl{ get;set;}
    }
}
