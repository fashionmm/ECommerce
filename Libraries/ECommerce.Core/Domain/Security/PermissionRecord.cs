using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Security
{
    /// <summary>
    /// 权限记录
    /// </summary>
    public partial class PermissionRecord : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;
        /// <summary>
        /// 获取或设置权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置权限系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置权限类别
        /// </summary>
        public string Category { get; set; }

        #region 导航属性
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get
            {
                return _customerRoles ?? (_customerRoles = new List<CustomerRole>());
            }
            protected set
            {
                _customerRoles = value;
            }
        }
        #endregion
    }
}
