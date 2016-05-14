using System.Collections.Generic;
using ECommerce.Core.Configuration;

namespace ECommerce.Core.Domain.Common
{
    public class CommonSettings : ISettings
    {
        public CommonSettings()
        {
            IgnoreLogWordlist = new List<string>();
        }

        public bool SubjectFieldOnContactUsForm { get; set; }
        public bool UseSystemEmailForContactUsForm { get; set; }

        public bool UseStoredProceduresIfSupported { get; set; }

        public bool HideAdvertisementsOnAdminArea { get; set; }

        public bool SitemapEnabled { get; set; }
        public bool SitemapIncludeCategories { get; set; }
        public bool SitemapIncludeManufacturers { get; set; }
        public bool SitemapIncludeProducts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否如果java脚本被禁用显示一个警告
        /// </summary>
        public bool DisplayJavaScriptDisabledWarning { get; set; }

        /// <summary>
        /// 获取或设置一个值，说明是否支持全文搜索
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        /// <summary>
        /// 获取或设置一个全文搜索模式
        /// </summary>
        public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应该记录404错误（页或文件未找到）
        /// </summary>
        public bool Log404Errors { get; set; }

        /// <summary>
        /// 获取或设置一个用于网站上的面包屑的分隔符
        /// </summary>
        public string BreadcrumbDelimiter { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否要渲染 <meta http-equiv="X-UA-Compatible" content="IE=edge"/> tag
        /// </summary>
        public bool RenderXuaCompatible { get; set; }

        /// <summary>
        /// 获取或设置一个值“X-UA-Compatible“meta标签
        /// </summary>
        public string XuaCompatibleValue { get; set; }

        /// <summary>
        /// 获取或设置一个忽略的词（短语）可以忽略，当记录错误信息
        /// </summary>
        public List<string> IgnoreLogWordlist { get; set; }
    }
}