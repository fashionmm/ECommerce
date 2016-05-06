using ECommerce.Core.Caching;
using ECommerce.Core.Data;
using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Customers
{
    /// <summary>
    /// 顾客服务接口实现
    /// </summary>
    public partial class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ICacheManager _cacheManager;
        #region 构造函数
        public CustomerService(ICacheManager cacheManager,
            IRepository<Customer> customerRepository)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
        }
        #endregion

    }
}
