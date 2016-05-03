namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// 表示商店映射记录
    /// </summary>
    public partial class StoreMapping : BaseEntity
    {
        /// <summary>
        ///获取或设置该实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 获取或设置该实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 获取或设置该商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        ///获取或设置商店
        /// </summary>
        public virtual Store Store { get; set; }
    }
}
