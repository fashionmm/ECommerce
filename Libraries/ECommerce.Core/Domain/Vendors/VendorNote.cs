using System;

namespace ECommerce.Core.Domain.Vendors
{
    /// <summary>
    /// 代表供应商的注意
    /// </summary>
    public partial class VendorNote : BaseEntity
    {
        /// <summary>
        /// 获取或设置供应商标识
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 获取或设置日期和供应商说明创作时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取供应商
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }

}
