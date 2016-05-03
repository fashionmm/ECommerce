using ECommerce.Core.Domain.Localization;
using ECommerce.Core.Domain.Shipping;
using ECommerce.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Directory
{
    public partial class Country : BaseEntity, ILocalizedEntity,
     IStoreMappingSupported
    {
        private ICollection<StateProvince> _stateProvinces;
        private ICollection<ShippingMethod> _restrictedShippingMethods;


        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许这个国家帐单
        /// </summary>
        public bool AllowsBilling { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许这个国家航运
        /// </summary>
        public bool AllowsShipping { get; set; }

        /// <summary>
        /// 获取或设置的两个字母的ISO代码
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// 获取或设置的三个字母的ISO代码
        /// </summary>
        public string ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// 获取或设置数值的ISO代码
        /// </summary>
        public int NumericIsoCode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该国家的客户是否必须收取欧盟的增值税
        /// </summary>
        public bool SubjectToVat { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置一个值，表示该实体是否是限制某些店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置州/省
        /// </summary>
        public virtual ICollection<StateProvince> StateProvinces
        {
            get { return _stateProvinces ?? (_stateProvinces = new List<StateProvince>()); }
            protected set { _stateProvinces = value; }
        }

        /// <summary>
        /// 获取或设置限制的运输方式
        /// </summary>
        public virtual ICollection<ShippingMethod> RestrictedShippingMethods
        {
            get { return _restrictedShippingMethods ?? (_restrictedShippingMethods = new List<ShippingMethod>()); }
            protected set { _restrictedShippingMethods = value; }
        }
    }
}
