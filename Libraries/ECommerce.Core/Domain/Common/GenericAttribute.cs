namespace ECommerce.Core.Domain.Common
{
    /// <summary>
    /// 表示一个通用属性对象
    /// </summary>
    public partial class GenericAttribute : BaseEntity
    {
        /// <summary>
        /// 获取或设置实体标识符
        /// </summary>
        public int EntityId { get; set; }
        
        /// <summary>
        /// 获取或设置键组
        /// </summary>
        public string KeyGroup { get; set; }

        /// <summary>
        ///获取或设置键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 获取或设置键值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 获取或设置商品标识符
        /// </summary>
        public int StoreId { get; set; }
        
    }
}
