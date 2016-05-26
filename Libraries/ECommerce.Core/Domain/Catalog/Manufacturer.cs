using ECommerce.Core.Domain.Discounts;
using ECommerce.Core.Domain.Localization;
using ECommerce.Core.Domain.Security;
using ECommerce.Core.Domain.Seo;
using ECommerce.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 制造商
    /// </summary>
    public partial class Manufacturer : BaseEntity, ILocalizedEntity,
        ISlugSupported, IAclSupported, IStoreMappingSupported
    {
        #region 字段
        private ICollection<Discount> _appliedDiscounts;
        #endregion

        /// <summary>
        /// 获取或设置制造商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置被使用的制造商模板标识符的值
        /// </summary>
        public int ManufacturerTemplateId { get; set; }

        /// <summary>
        /// 获取或设置Meta关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        ///  获取或设置Meta描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// 获取或设置Meta标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 获取或设置父 级图片标识
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// 获取或设置一个值，是否容许顾客选择页面大小
        /// </summary>
        public int AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// 获取或设置可供顾客选择页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// 获取或设置可用的价格范围
        /// </summary>
        public string PriceRanges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SubjectToAcl { get; set; }

        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        #region 导航
        public virtual ICollection<Discount> AppliedDiscounts
        {
            get
            {
                return (_appliedDiscounts ?? new List<Discount>());
            }
            protected set
            {
                _appliedDiscounts = value;
            }
        }
        #endregion
    }
}
