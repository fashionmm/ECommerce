using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Infrastructure
{
    /// <summary>
    /// 描述一种以机器的名称运行应用程序的服务。
    /// </summary>
    public interface IMachineNameProvider
    {
        /// <summary>
        /// 返回运行应用程序的机器的名称（实例）。
        /// </summary>
        /// <returns></returns>
        string GetMachineName();
    }
}
