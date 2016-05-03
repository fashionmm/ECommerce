namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// ��ʾ�̵�ӳ���¼
    /// </summary>
    public partial class StoreMapping : BaseEntity
    {
        /// <summary>
        ///��ȡ�����ø�ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// ��ȡ�����ø�ʵ������
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// ��ȡ�����ø��̵��ʶ��
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        ///��ȡ�������̵�
        /// </summary>
        public virtual Store Store { get; set; }
    }
}
