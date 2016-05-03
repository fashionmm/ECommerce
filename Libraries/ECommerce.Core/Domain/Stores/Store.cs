using ECommerce.Core.Domain.Localization;

namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// ������һ���̵�
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�������̵�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�������̵��URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�Ƿ�����SSL
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// ��ȡ�������̵갲ȫ��ַ��HTTPS��
        /// </summary>
        public string SecureUrl { get; set; }

        /// <summary>
        /// ��ȡ�������Զ��ŷָ���ֵ�б��п��ܵ�HTTP_HOST��
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// ��ȡ�����ô��̵��Ĭ�����Եı�ʶ����0�ǵ�����ʹ��Ĭ��������ʾ˳��ʱ���õ�
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾����
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾��ַ
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾�绰����
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// ��ȡ�����øù�˾����ֵ˰����ŷ�����˹���ʹ�ã�
        /// </summary>
        public string CompanyVat { get; set; }
    }
}
