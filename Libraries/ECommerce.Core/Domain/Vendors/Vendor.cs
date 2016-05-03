using System.Collections.Generic;
using ECommerce.Core.Domain.Localization;
using ECommerce.Core.Domain.Seo;

namespace ECommerce.Core.Domain.Vendors
{
    /// <summary>
    /// ��ʾ��Ӧ��
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<VendorNote> _vendorNotes;

        /// <summary>
        /// ��ȡ�����ù�Ӧ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  ��ȡ�����ù�Ӧ��Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  ��ȡ����������
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        ///  ��ȡ������ͼƬ��ʶ
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��ʵ���Ƿ��ǻ��
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��ʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }


        /// <summary>
        /// ��ȡ������meta�ؼ���
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// ��ȡ������meta����
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///��ȡ������meta����
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// ��ȡ������ҳ���С
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�ͻ�����ѡ��ҳ���С
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// ��ȡ�����ÿɹ��˿�ѡ��ҳ���Сѡ��
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// ��ȡ�����ù�Ӧ��˵��
        /// </summary>
        public virtual ICollection<VendorNote> VendorNotes
        {
            get { return _vendorNotes ?? (_vendorNotes = new List<VendorNote>()); }
            protected set { _vendorNotes = value; }
        }

    }
}
