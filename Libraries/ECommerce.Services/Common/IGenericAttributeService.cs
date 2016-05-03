using System.Collections.Generic;
using ECommerce.Core;
using ECommerce.Core.Domain.Common;

namespace ECommerce.Services.Common
{
    /// <summary>
    /// ͨ�����Է���ӿ�
    /// </summary>
    public partial interface IGenericAttributeService
    {
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="attribute">Attribute</param>
        void DeleteAttribute(GenericAttribute attribute);

        /// <summary>
        /// ��������ID��ȡһ�����Զ���
        /// </summary>
        /// <param name="attributeId">Attribute identifier</param>
        /// <returns>An attribute</returns>
        GenericAttribute GetAttributeById(int attributeId);

        /// <summary>
        /// ���һ������
        /// </summary>
        /// <param name="attribute">attribute</param>
        void InsertAttribute(GenericAttribute attribute);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="attribute">Attribute</param>
        void UpdateAttribute(GenericAttribute attribute);

        /// <summary>
        /// ��ȡʵ����������
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup);
        
        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0);
    }
}