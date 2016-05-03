using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Orders
{
    /// <summary>
    /// 表示退货申请
    /// </summary>
    public partial class ReturnRequest : BaseEntity
    {
        /// <summary>
        /// 获取或设置商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置订单项目标识
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// 获取或设置顾客标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 取或设置退货的原因
        /// </summary>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// 获取或设置申请的操作
        /// </summary>
        public string RequestedAction { get; set; }

        /// <summary>
        /// 获取或设置顾客评论
        /// </summary>
        public string CustomerComments { get; set; }

        /// <summary>
        /// 获取或设置工作人员须知
        /// </summary>
        public string StaffNotes { get; set; }

        /// <summary>
        /// 获取或设置退货申请状态标识
        /// </summary>
        public int ReturnRequestStatusId { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实体更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置退货申请状态
        /// </summary>
        public ReturnRequestStatus ReturnRequestStatus
        {
            get
            {
                return (ReturnRequestStatus)this.ReturnRequestStatusId;
            }
            set
            {
                this.ReturnRequestStatusId = (int)value;
            }
        }

        /// <summary>
        ///获取或设置顾客
        /// </summary>
        public virtual Customer Customer { get; set; }
    }

}
