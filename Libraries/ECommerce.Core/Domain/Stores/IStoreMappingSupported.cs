namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// ����һ��ʵ�壬֧�ִ洢ӳ��
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��ʵ���Ƿ���������ĳЩ�洢��
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
