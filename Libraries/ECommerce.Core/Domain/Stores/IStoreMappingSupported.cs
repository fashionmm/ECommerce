namespace ECommerce.Core.Domain.Stores
{
    /// <summary>
    /// 代表一个实体，支持商店映射
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// 获取或设置一个值，该值指示该实体是否是受限于某些商店的
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
