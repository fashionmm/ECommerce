using ECommerce.Core.Domain.Catalog;
using ECommerce.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Common
{
    /// <summary>
    /// 地址属性类
    /// </summary>
    public partial class AddressAttribute : BaseEntity, ILocalizedEntity
    {
        private ICollection<AddressAttributeValue> _addressAttributeValues;
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 获取或设置属性控制类型标识符
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// 显示序号
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 控件类型属性对象
        /// </summary>
        public AttributeControlType AttributeControlType
        {
            get
            {
                return (AttributeControlType)this.AttributeControlTypeId;
            }
            set
            {
                this.AttributeControlTypeId = (int)value;
            }
        }

        public virtual ICollection<AddressAttributeValue> AddressAttributeValues
        {

            get
            {
                return _addressAttributeValues ?? (_addressAttributeValues = new List<AddressAttributeValue>());
            }
            protected set
            {
                _addressAttributeValues = value;
            }

        }
    }
}
