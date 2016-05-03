using System.Collections.Generic;
using ECommerce.Core.Domain.Stores;

namespace ECommerce.Services.Stores
{
    /// <summary>
    /// 商店服务接口
    /// </summary>
    public partial interface IStoreService
    {
        /// <summary>
        /// 删除一个商店
        /// </summary>
        /// <param name="store">Store</param>
        void DeleteStore(Store store);

        /// <summary>
        /// 获取所有商店
        /// </summary>
        /// <returns>Stores</returns>
        IList<Store> GetAllStores();

        /// <summary>
        /// 根据商店ID获取商店信息
        /// </summary>
        /// <param name="storeId">商店标识符</param>
        /// <returns>Store</returns>
        Store GetStoreById(int storeId);

        /// <summary>
        /// 添加一个商店
        /// </summary>
        /// <param name="store">Store</param>
        void InsertStore(Store store);

        /// <summary>
        /// 更新一个商店
        /// </summary>
        /// <param name="store">Store</param>
        void UpdateStore(Store store);
    }
}