using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Customers
{
    /// <summary>
    /// 客户注册类型fortatting枚举
    /// </summary>
    public enum UserRegistrationType
    {
        /// <summary>
        /// 标准帐户创建
        /// </summary>
        Standard = 1,
        /// <summary>
        /// 注册登记后需进行电子邮件验证
        /// </summary>
        EmailValidation = 2,
        /// <summary>
        /// 需管理员批准
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// 注册被禁用
        /// </summary>
        Disabled = 4,
    }

}
