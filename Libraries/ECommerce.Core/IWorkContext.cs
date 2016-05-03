using ECommerce.Core.Domain.Customers;
using ECommerce.Core.Domain.Vendors;
using ECommerce.Core.Domain.Directory;
using ECommerce.Core.Domain.Localization;
using ECommerce.Core.Domain.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECommerce.Core
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// 获取或设置当前顾客
        /// </summary>
        Customer CurrentCustomer { get; set; }
        /// <summary>
        /// 获取或设置原始客户 (in case the current one is impersonated)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }
        /// <summary>
        /// 获取或设置当前供应商 (logged-in manager)
        /// </summary>
        Vendor CurrentVendor { get; }

        /// <summary>
        /// 获取或设置当前用户工作语言
        /// </summary>
        Language WorkingLanguage { get; set; }
        /// <summary>
        /// 获取或设置当前用户工作货币
        /// </summary>
        Currency WorkingCurrency { get; set; }
        /// <summary>
        /// 获取或设置当前税务显示类型
        /// </summary>
        TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// 获取或设置值，指示是否在管理区域中
        /// </summary>
        bool IsAdmin { get; set; }
    }

}
