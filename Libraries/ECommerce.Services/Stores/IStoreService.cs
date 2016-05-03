using System.Collections.Generic;
using ECommerce.Core.Domain.Stores;

namespace ECommerce.Services.Stores
{
    /// <summary>
    /// �̵����ӿ�
    /// </summary>
    public partial interface IStoreService
    {
        /// <summary>
        /// ɾ��һ���̵�
        /// </summary>
        /// <param name="store">Store</param>
        void DeleteStore(Store store);

        /// <summary>
        /// ��ȡ�����̵�
        /// </summary>
        /// <returns>Stores</returns>
        IList<Store> GetAllStores();

        /// <summary>
        /// �����̵�ID��ȡ�̵���Ϣ
        /// </summary>
        /// <param name="storeId">�̵��ʶ��</param>
        /// <returns>Store</returns>
        Store GetStoreById(int storeId);

        /// <summary>
        /// ���һ���̵�
        /// </summary>
        /// <param name="store">Store</param>
        void InsertStore(Store store);

        /// <summary>
        /// ����һ���̵�
        /// </summary>
        /// <param name="store">Store</param>
        void UpdateStore(Store store);
    }
}