using ECommerce.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Customers
{
    /// <summary>
    /// 顾客角色
    /// </summary>
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;

        /// <summary>
        /// 获取或设置顾客角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否顾客角色标记为免费送货
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示顾客角色是否标记为免税
        /// </summary>
        public bool TaxExempt { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户角色是否是激活状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示顾客角色是否为系统角色
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// 获取或设置顾客角色系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置一个产品标识是由该客户角色要求
        /// 一旦指定的产品被购买，顾客被添加到这个顾客角色，
        /// </summary>
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        /// 获取或设置权限记录
        /// </summary>
        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }

}
