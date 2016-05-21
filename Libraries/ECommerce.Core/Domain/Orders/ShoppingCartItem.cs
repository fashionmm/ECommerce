using ECommerce.Core.Domain.Catalog;
using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Orders
{
    /// <summary>
    /// 购物车
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity
    {
        /// <summary>
        /// 获取或设置店铺标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置购物车类型标识
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// 获取或设置顾客标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置商品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置产品属性用XML格式
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 获取或设置商品采购进价
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }
       /// <summary>
       /// 获取或设置商品采购数量
       /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置租赁产品开始日期（如果为空，则不是租赁产品）
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }
        
        /// <summary>
        /// 获取或设置租赁产品结束日期（如果为空，则不是租赁产品）
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

       /// <summary>
        /// 获取或设置购物车项目创建时间
       /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置购物车项目更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置购物车类型
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get
            {
                return (ShoppingCartType)this.ShoppingCartTypeId;
            }
            set
            {
                this.ShoppingCartTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取一个值，指示购物车项目是否是免费运输。
        /// </summary>
        public bool IsFreeShipping
        {
            get { 
                var product=this.Product;
                if(product!=null)
                    return product.IsFreeShipping;
                return true;
            }
           
        }

        public bool IsShipEnabled
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsShipEnabled;
                return false;
            }
        }

        /// <summary>
        /// 获取额外的运输费用
        /// </summary>
        public decimal AdditionalShippingCharge
        {
            get
            {
                decimal additionalShippingCharge = decimal.Zero;
                var product = this.Product;
                if (product != null)
                    additionalShippingCharge = product.AdditionalShippingCharge * Quantity;
                return additionalShippingCharge;
            }
        }

        public bool IsTaxExempt
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsTaxExempt;
                return false;
            }
        }
        #region 属性导航
        /// <summary>
        /// 
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; set; }

        #endregion
    }
}
