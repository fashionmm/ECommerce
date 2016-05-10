using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECommerce.Web.Framework.Themes
{
    /// <summary>
    /// 主题配置信息类
    /// </summary>
    public class ThemeConfiguration
    {
        public ThemeConfiguration(string themeName, string path, XmlDocument doc)
        {
            ThemeName = themeName;
            Path = path;
            var node = doc.SelectSingleNode("Theme");
            if (node != null)
            {
                ConfigurationNode = node;
                var attribute = node.Attributes["title"];
                ThemeTitle = attribute == null ? string.Empty : attribute.Value;
                attribute = node.Attributes["supportRTL"];
                SupportRtl = attribute == null ? false : bool.Parse(attribute.Value);
                attribute = node.Attributes["previewImageUrl"];
                PreviewImageUrl = attribute == null ? string.Empty : attribute.Value;
                attribute = node.Attributes["previewText"];
                PreviewText = attribute == null ? string.Empty : attribute.Value;
            }
        }

        public XmlNode ConfigurationNode { get; protected set; }

        public string Path { get; protected set; }

        public string PreviewImageUrl { get; protected set; }

        public string PreviewText { get; protected set; }

        public bool SupportRtl { get; protected set; }

        public string ThemeName { get; protected set; }

        public string ThemeTitle { get; protected set; }
    }
}
