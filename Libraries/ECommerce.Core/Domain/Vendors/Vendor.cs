using System.Collections.Generic;
using ECommerce.Core.Domain.Localization;
using ECommerce.Core.Domain.Seo;

namespace ECommerce.Core.Domain.Vendors
{
    /// <summary>
    /// 表示供应商
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<VendorNote> _vendorNotes;

        /// <summary>
        /// 获取或设置供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  获取或设置供应商Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  获取或设置描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        ///  获取或设置图片标识
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该实体是否是活动的
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }


        /// <summary>
        /// 获取或设置meta关键词
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// 获取或设置meta描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///获取或设置meta标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否客户可以选择页面大小
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// 获取或设置可供顾客选择页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// 获取或设置供应商说明
        /// </summary>
        public virtual ICollection<VendorNote> VendorNotes
        {
            get { return _vendorNotes ?? (_vendorNotes = new List<VendorNote>()); }
            protected set { _vendorNotes = value; }
        }

    }
}
