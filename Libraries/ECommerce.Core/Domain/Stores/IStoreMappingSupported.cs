namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// ����һ��ʵ�壬֧���̵�ӳ��
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��ʵ���Ƿ���������ĳЩ�̵��
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
