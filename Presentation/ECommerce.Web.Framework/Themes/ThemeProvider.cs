using ECommerce.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECommerce.Web.Framework.Themes
{
    public partial class ThemeProvider : IThemeProvider
    {
        #region 字段
        private readonly IList<ThemeConfiguration> _themeConfigurations = new List<ThemeConfiguration>();

        private readonly string _basePath = string.Empty;
        #endregion

        #region 构造函数
        public ThemeProvider(IWebHelper webHelper)
        {
            _basePath=webHelper.MapPath("~/Themes/");
            LoadConfigurations();
        }
        #endregion

       
     
        #region IThemeProvider 接口实现
        public ThemeConfiguration GetThemeConfiguration(string themeName)
        {
            return _themeConfigurations
                .SingleOrDefault(x=>x.ThemeName.Equals(themeName,StringComparison.InvariantCultureIgnoreCase));
        }

        public IList<ThemeConfiguration> GetThemeConfigurations()
        {
            return _themeConfigurations;
        }

        public bool ThemeConfigurationExists(string themeName)
        {
            return false;
                
        }
        #endregion

        #region 工具方法
        private void LoadConfigurations()
        {
            foreach (string themeName in Directory.GetDirectories(_basePath))
            {
                var configuration = CreateThemeConfiguration(themeName);
                if (configuration != null)
                {
                    _themeConfigurations.Add(configuration);
                }
            }
        }
       

        private ThemeConfiguration CreateThemeConfiguration(string themePath)
        {
            var themeDirectory = new DirectoryInfo(themePath);
            var themeConfigFile = new FileInfo(Path.Combine(themeDirectory.FullName,"theme.config"));
            if (themeConfigFile.Exists)
            {
                var doc = new XmlDocument();
                doc.Load(themeConfigFile.FullName);
                return new ThemeConfiguration(themeDirectory.Name,themeDirectory.FullName,doc);
            }

            return null;
        }

        #endregion
    }
}
