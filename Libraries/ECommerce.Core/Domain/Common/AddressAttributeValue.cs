using ECommerce.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Common
{
    public partial class AddressAttributeValue:BaseEntity,ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置地址属性标识
        /// </summary>
        public int AddressAttributeId { get; set; }

        /// <summary>
        /// 获取或设置校验属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该值是否预先选定
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 地址属性对象导航
        /// </summary>
        public virtual AddressAttribute AddressAttribute { get; set; }
    }
}
