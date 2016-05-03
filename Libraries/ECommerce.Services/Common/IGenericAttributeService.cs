using System.Collections.Generic;
using ECommerce.Core;
using ECommerce.Core.Domain.Common;

namespace ECommerce.Services.Common
{
    /// <summary>
    /// 通用属性服务接口
    /// </summary>
    public partial interface IGenericAttributeService
    {
        /// <summary>
        /// 删除一个属性
        /// </summary>
        /// <param name="attribute">Attribute</param>
        void DeleteAttribute(GenericAttribute attribute);

        /// <summary>
        /// 根据属性ID获取一个属性对象
        /// </summary>
        /// <param name="attributeId">Attribute identifier</param>
        /// <returns>An attribute</returns>
        GenericAttribute GetAttributeById(int attributeId);

        /// <summary>
        /// 添加一个属性
        /// </summary>
        /// <param name="attribute">attribute</param>
        void InsertAttribute(GenericAttribute attribute);

        /// <summary>
        /// 更新一个属性
        /// </summary>
        /// <param name="attribute">Attribute</param>
        void UpdateAttribute(GenericAttribute attribute);

        /// <summary>
        /// 获取实例对象属性
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup);
        
        /// <summary>
        /// 保存属性值
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0);
    }
}