namespace ECommerce.Core.Domain.Common
{
    /// <summary>
    /// ��ʾһ��ͨ�����Զ���
    /// </summary>
    public partial class GenericAttribute : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }
        
        /// <summary>
        /// ��ȡ�����ü���
        /// </summary>
        public string KeyGroup { get; set; }

        /// <summary>
        ///��ȡ�����ü�
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// ��ȡ�����ü�ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ��ȡ��������Ʒ��ʶ��
        /// </summary>
        public int StoreId { get; set; }
        
    }
}
