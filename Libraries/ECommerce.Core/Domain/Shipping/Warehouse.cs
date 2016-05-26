using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Shipping
{
    /// <summary>
    /// 仓库
    /// </summary>
    public partial class Warehouse : BaseEntity
    {

        /// <summary>
        /// 获取或设置仓库名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置管理评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置仓库地址标识
        /// </summary>
        public int AddressId { get; set; }
    }
}
