using ECommerce.Core.Domain.Directory;
using ECommerce.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECommerce.Core.Domain.Shipping
{
    /// <summary>
    /// 代表航运法（用于离线运费率计算方法）
    /// </summary>
    public partial class ShippingMethod : BaseEntity, ILocalizedEntity
    {
        private ICollection<Country> _restrictedCountries;

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置受限制的国家
        /// </summary>
        public virtual ICollection<Country> RestrictedCountries
        {
            get { return _restrictedCountries ?? (_restrictedCountries = new List<Country>()); }
            protected set { _restrictedCountries = value; }
        }
    }
}
