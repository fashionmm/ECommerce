using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 租赁产品周期（价格）
    /// </summary>
    public enum RentalPricePeriod
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
