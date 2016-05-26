using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Media
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Picture : BaseEntity
    {
        /// <summary>
        /// 获取或设置图片二进制
        /// </summary>
        public byte[] PictureBinary { get; set; }

        /// <summary>
        /// 获取或设置图片的MIME类型
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// 获取或设置图片的SEO friednly文件名
        /// </summary>
        public string SeoFilename { get; set; }

        /// <summary>
        /// 获取或设置“alt”属性为“IMG”HTML元素。
        /// 如果为空，则将使用默认规则（例如产品名称
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// 获取或设置“标题”属性为“IMG”HTML元素。
        /// 如果为空，则将使用默认的规则（例如产品名称）
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示图片是否是新的
        /// </summary>
        public bool IsNew { get; set; }
    }
}
