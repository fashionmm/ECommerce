using ECommerce.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Catalog
{
    /// <summary>
    /// 产品图片映射
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        public int ProductId { get; set; }

        public int PictureId { get; set; }

        public int DisplayOrder { get; set; }

        #region 导航
        public virtual Picture Picture { get; set; }

        public virtual Product Product { get; set; }

        #endregion
    }
}
