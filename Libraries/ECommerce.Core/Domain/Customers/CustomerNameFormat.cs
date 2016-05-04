using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Customers
{
    /// <summary>
    /// 代表客户的名字fortatting枚举
    /// </summary>
    public enum CustomerNameFormat
    {
        /// <summary>
        /// 显示邮箱
        /// </summary>
        ShowEmails = 1,
        /// <summary>
        /// 显示用户名
        /// </summary>
        ShowUsernames = 2,
        /// <summary>
        /// 显示全称
        /// </summary>
        ShowFullNames = 3,
        /// <summary>
        /// 显示第一名字
        /// </summary>
        ShowFirstName = 10
    }

}
