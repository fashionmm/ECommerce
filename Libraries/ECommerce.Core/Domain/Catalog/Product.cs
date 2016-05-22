using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Product : BaseEntity
    {
        /// <summary>
        /// 获取或设置商品类型标识
        /// </summary>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// 获取或设置父产品标识符。它是用来识别相关联的产品（只用于“分组”产品）
        /// </summary>
        public int ParentGroupedProductId { get; set; }

        /// <summary>
        ///  获取或设置该产品是否在目录或搜索结果中可见的值。
        ///  它的使用时，该产品是相关的一些“分组”
        /// 这样，相关产品可以访问/添加等只是从一组产品详情页
        /// </summary>
        public int VisableIndividually { get; set; }

        /// <summary>
        /// 获取或设置商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置简短描述
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// 获取或设置完整描述
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// 获取或设置管理评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置被使用产品模板标识值
        /// </summary>
        public int ProductTemplateId { get; set; }

        /// <summary>
        /// 获取或设置供应商标识
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示产品在首页
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 获取或设置Meta（元）关键词
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// 获取或设置Meta（元） 描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// 获取或设置Meta 标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否允许顾客评论
        /// </summary>
        public bool AllowCustomerReviews { get; set; }

        /// <summary>
        /// 获取或设置评分总和（认可的评论）
        /// </summary>
        public int ApprovedRatingSum { get; set; }

        /// <summary>
        /// 获取或设置评分总和（不认可的评论）
        /// </summary>
        public int NotApprovedRatingSum { get; set; }

        /// <summary>
        /// 获取或设置总的评价票（经批准的评论）
        /// </summary>
        public int ApprovedTotalReviews { get; set; }

        /// <summary>
        /// 获取或设置总的评价票（未经批准的评论）
        /// </summary>
        public int NotApprovedTotalReviews { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否受到ACL
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// 获取或设置一个值，表示该实体是否是限制某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置SKU(最小存货单位)
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 获取或设置制造商零件编号
        /// </summary>
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// 获取或设置全球贸易项目号码或集（GTIN）。
        /// 标识符包含 UPC (北美), EAN (欧洲), 
        /// JAN (日本), 和国际标准书号ISBN (书籍).
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否为礼品卡
        /// </summary>
        public bool IsGiftCard { get; set; }

        /// <summary>
        /// 获取或设置礼品类型标识
        /// </summary>
        public int GiftCardTypeId { get; set; }

        /// <summary>
        /// 获取或设置可用于购买后的礼品卡金额。如果未指定，则产品价格将使用。
        /// </summary>
        public decimal? OverriddenGiftCardAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RequireOtherProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequireProductIds { get; set; }

        public bool AutomaticallyAddRequireProducts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否可以下载
        /// </summary>
        public bool IsDownload { get; set; }

        /// <summary>
        ///获取或设置下载标识符
        /// </summary>
        public int DownloadId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该下载的产品是否可以被下载次数不限
        /// </summary>
        public bool UnlimitedDownloads { get; set; }

        /// <summary>
        /// 获取或设置下载的最大数量
        /// </summary>
        public int MaxNumberOfDownloads { get; set; }

        /// <summary>
        /// 获取或设置在客户保持访问该文件的天数。
        /// </summary>
        public int? DownloadExpirationDays { get; set; }

        /// <summary>
        /// 获取或设置下载激活类型
        /// </summary>
        public int DownloadActivationTypeId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否具有示例下载文件
        /// </summary>
        public bool HasSampleDownload { get; set; }

        /// <summary>
        /// 获取或设置示例下载标识符
        /// </summary>
        public int SampleDownloadId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否有用户协议
        /// </summary>
        public bool HasUserAgreement { get; set; }

        /// <summary>
        /// 获取或设置许可协议文本
        /// </summary>
        public string UserAgreementText { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该产品是否重复出现
        /// </summary>
        public bool IsRecurring { get; set; }

        /// <summary>
        /// 获取或设置循环长度
        /// </summary>
        public int RecurringCycleLength { get; set; }

        /// <summary>
        /// Gets or sets the cycle period
        /// </summary>
        public int RecurringCyclePeriodId { get; set; }
        /// <summary>
        /// Gets or sets the total cycles
        /// </summary>
        public int RecurringTotalCycles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is rental
        /// </summary>
        public bool IsRental { get; set; }
        /// <summary>
        /// Gets or sets the rental length for some period (price for this period)
        /// </summary>
        public int RentalPriceLength { get; set; }
        /// <summary>
        /// Gets or sets the rental period (price for this period)
        /// </summary>
        public int RentalPricePeriodId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is ship enabled
        /// </summary>
        public bool IsShipEnabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is free shipping
        /// </summary>
        public bool IsFreeShipping { get; set; }
        /// <summary>
        /// Gets or sets a value this product should be shipped separately (each item)
        /// </summary>
        public bool ShipSeparately { get; set; }
        /// <summary>
        /// Gets or sets the additional shipping charge
        /// </summary>
        public decimal AdditionalShippingCharge { get; set; }
        /// <summary>
        /// Gets or sets a delivery date identifier
        /// </summary>
        public int DeliveryDateId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is marked as tax exempt
        /// </summary>
        public bool IsTaxExempt { get; set; }
        /// <summary>
        /// Gets or sets the tax category identifier
        /// </summary>
        public int TaxCategoryId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is telecommunications or broadcasting or electronic services
        /// </summary>
        public bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how to manage inventory
        /// </summary>
        public int ManageInventoryMethodId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether multiple warehouses are used for this product
        /// </summary>
        public bool UseMultipleWarehouses { get; set; }
        /// <summary>
        /// Gets or sets a warehouse identifier
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock availability
        /// </summary>
        public bool DisplayStockAvailability { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock quantity
        /// </summary>
        public bool DisplayStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the minimum stock quantity
        /// </summary>
        public int MinStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the low stock activity identifier
        /// </summary>
        public int LowStockActivityId { get; set; }
        /// <summary>
        /// Gets or sets the quantity when admin should be notified
        /// </summary>
        public int NotifyAdminForQuantityBelow { get; set; }
        /// <summary>
        /// Gets or sets a value backorder mode identifier
        /// </summary>
        public int BackorderModeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
        /// </summary>
        public bool AllowBackInStockSubscriptions { get; set; }
        /// <summary>
        /// Gets or sets the order minimum quantity
        /// </summary>
        public int OrderMinimumQuantity { get; set; }
        /// <summary>
        /// Gets or sets the order maximum quantity
        /// </summary>
        public int OrderMaximumQuantity { get; set; }
        /// <summary>
        /// Gets or sets the comma seperated list of allowed quantities. null or empty if any quantity is allowed
        /// </summary>
        public string AllowedQuantities { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
        /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
        /// </summary>
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable buy (Add to cart) button
        /// </summary>
        public bool DisableBuyButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to disable "Add to wishlist" button
        /// </summary>
        public bool DisableWishlistButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this item is available for Pre-Order
        /// </summary>
        public bool AvailableForPreOrder { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the product availability (for pre-order products)
        /// </summary>
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// </summary>
        public bool CallForPrice { get; set; }
        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the old price
        /// </summary>
        public decimal OldPrice { get; set; }
        /// <summary>
        /// Gets or sets the product cost
        /// </summary>
        public decimal ProductCost { get; set; }
        /// <summary>
        /// Gets or sets the product special price
        /// </summary>
        public decimal? SpecialPrice { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the special price
        /// </summary>
        public DateTime? SpecialPriceStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the end date and time of the special price
        /// </summary>
        public DateTime? SpecialPriceEndDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a customer enters price
        /// </summary>
        public bool CustomerEntersPrice { get; set; }
        /// <summary>
        /// Gets or sets the minimum price entered by a customer
        /// </summary>
        public decimal MinimumCustomerEnteredPrice { get; set; }
        /// <summary>
        /// Gets or sets the maximum price entered by a customer
        /// </summary>
        public decimal MaximumCustomerEnteredPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
        /// </summary>
        public bool BasepriceEnabled { get; set; }
        /// <summary>
        /// Gets or sets an amount in product for PAngV
        /// </summary>
        public decimal BasepriceAmount { get; set; }
        /// <summary>
        /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
        /// </summary>
        public int BasepriceUnitId { get; set; }
        /// <summary>
        /// Gets or sets a reference amount for PAngV
        /// </summary>
        public decimal BasepriceBaseAmount { get; set; }
        /// <summary>
        /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
        /// </summary>
        public int BasepriceBaseUnitId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this product is marked as new
        /// </summary>
        public bool MarkAsNew { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
        /// </summary>
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
        /// </summary>
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this product has tier prices configured
        /// <remarks>The same as if we run this.TierPrices.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load tier prices navigation property
        /// </remarks>
        /// </summary>
        public bool HasTierPrices { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this product has discounts applied
        /// <remarks>The same as if we run this.AppliedDiscounts.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load Applied Discounts navigation property
        /// </remarks>
        /// </summary>
        public bool HasDiscountsApplied { get; set; }

        /// <summary>
        /// Gets or sets the weight
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Gets or sets the length
        /// </summary>
        public decimal Length { get; set; }
        /// <summary>
        /// Gets or sets the width
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
        public DateTime? AvailableStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
        public DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets a display order.
        /// This value is used when sorting associated products (used with "grouped" products)
        /// This value is used when sorting home page products
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

/// <summary>
        /// 获取或设置产品类型
        /// </summary>
        public ProductType ProductType
        {
            get
            {
                return (ProductType)this.ProductTypeId;
            }
            set
            {
                this.ProductTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置缺货模式
        /// </summary>
        public BackorderMode BackorderMode
        {
            get
            {
                return (BackorderMode)this.BackorderModeId;
            }
            set
            {
                this.BackorderModeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置下载激活类型
        /// </summary>
        public DownloadActivationType DownloadActivationType
        {
            get
            {
                return (DownloadActivationType)this.DownloadActivationTypeId;
            }
            set
            {
                this.DownloadActivationTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置礼品卡类型
        /// </summary>
        public GiftCardType GiftCardType
        {
            get
            {
                return (GiftCardType)this.GiftCardTypeId;
            }
            set
            {
                this.GiftCardTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置低库存活动
        /// </summary>
        public LowStockActivity LowStockActivity
        {
            get
            {
                return (LowStockActivity)this.LowStockActivityId;
            }
            set
            {
                this.LowStockActivityId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置指示如何管理库存的值
        /// </summary>
        public ManageInventoryMethod ManageInventoryMethod
        {
            get
            {
                return (ManageInventoryMethod)this.ManageInventoryMethodId;
            }
            set
            {
                this.ManageInventoryMethodId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置重复的产品周期
        /// </summary>
        public RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get
            {
                return (RecurringProductCyclePeriod)this.RecurringCyclePeriodId;
            }
            set
            {
                this.RecurringCyclePeriodId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置租用产品的时间段
        /// </summary>
        public RentalPricePeriod RentalPricePeriod
        {
            get
            {
                return (RentalPricePeriod)this.RentalPricePeriodId;
            }
            set
            {
                this.RentalPricePeriodId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置产品类别的集合
        /// </summary>
        public virtual ICollection<ProductCategory> ProductCategories
        {
            get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
            protected set { _productCategories = value; }
        }

        /// <summary>
        /// Gets or sets the collection of ProductManufacturer
        /// </summary>
        public virtual ICollection<ProductManufacturer> ProductManufacturers
        {
            get { return _productManufacturers ?? (_productManufacturers = new List<ProductManufacturer>()); }
            protected set { _productManufacturers = value; }
        }

        /// <summary>
        /// Gets or sets the collection of ProductPicture
        /// </summary>
        public virtual ICollection<ProductPicture> ProductPictures
        {
            get { return _productPictures ?? (_productPictures = new List<ProductPicture>()); }
            protected set { _productPictures = value; }
        }

        /// <summary>
        /// Gets or sets the collection of product reviews
        /// </summary>
        public virtual ICollection<ProductReview> ProductReviews
        {
            get { return _productReviews ?? (_productReviews = new List<ProductReview>()); }
            protected set { _productReviews = value; }
        }

        /// <summary>
        /// Gets or sets the product specification attribute
        /// </summary>
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes
        {
            get { return _productSpecificationAttributes ?? (_productSpecificationAttributes = new List<ProductSpecificationAttribute>()); }
            protected set { _productSpecificationAttributes = value; }
        }

        /// <summary>
        /// Gets or sets the product tags
        /// </summary>
        public virtual ICollection<ProductTag> ProductTags
        {
            get { return _productTags ?? (_productTags = new List<ProductTag>()); }
            protected set { _productTags = value; }
        }

        /// <summary>
        /// Gets or sets the product attribute mappings
        /// </summary>
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings
        {
            get { return _productAttributeMappings ?? (_productAttributeMappings = new List<ProductAttributeMapping>()); }
            protected set { _productAttributeMappings = value; }
        }

        /// <summary>
        /// Gets or sets the product attribute combinations
        /// </summary>
        public virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations
        {
            get { return _productAttributeCombinations ?? (_productAttributeCombinations = new List<ProductAttributeCombination>()); }
            protected set { _productAttributeCombinations = value; }
        }

        /// <summary>
        /// Gets or sets the tier prices
        /// </summary>
        public virtual ICollection<TierPrice> TierPrices
        {
            get { return _tierPrices ?? (_tierPrices = new List<TierPrice>()); }
            protected set { _tierPrices = value; }
        }

        /// <summary>
        /// Gets or sets the collection of applied discounts
        /// </summary>
        public virtual ICollection<Discount> AppliedDiscounts
        {
            get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
            protected set { _appliedDiscounts = value; }
        }
        
        /// <summary>
        /// Gets or sets the collection of "ProductWarehouseInventory" records. We use it only when "UseMultipleWarehouses" is set to "true" and ManageInventoryMethod" to "ManageStock"
        /// </summary>
        public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventory
        {
            get { return _productWarehouseInventory ?? (_productWarehouseInventory = new List<ProductWarehouseInventory>()); }
            protected set { _productWarehouseInventory = value; }
        }
    }


    
}
