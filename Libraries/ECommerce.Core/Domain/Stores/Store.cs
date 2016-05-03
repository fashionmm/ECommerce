using ECommerce.Core.Domain.Localization;

namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// 代表了一个商店
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置商店名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置商店的URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否启用SSL
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// 获取或设置商店安全网址（HTTPS）
        /// </summary>
        public string SecureUrl { get; set; }

        /// <summary>
        /// 获取或设置以逗号分隔的值列表中可能的HTTP_HOST。
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// 获取或设置此商店的默认语言的标识符；0是当我们使用默认语言显示顺序时设置的
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 获取或设置公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 获取或设置公司电话号码
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// 获取或设置该公司的增值税（在欧洲联盟国家使用）
        /// </summary>
        public string CompanyVat { get; set; }
    }
}
