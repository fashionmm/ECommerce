using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 重复的产品周期
    /// </summary>
    public enum RecurringProductCyclePeriod
    {
        /// <summary>
        /// Days
        /// </summary>
        Days = 0,
        /// <summary>
        /// Weeks
        /// </summary>
        Weeks = 10,
        /// <summary>
        /// Months
        /// </summary>
        Months = 20,
        /// <summary>
        /// Years
        /// </summary>
        Years = 30,

    }
}
