using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Web.Framework.Themes
{
    /// <summary>
    /// 主题上下文
    /// </summary>
  public interface  IThemeContext
    {
      /// <summary>
      /// 获取或设置当前主题系统的名称
      /// </summary>
      string WorkingThemeName { get; set; }
    }
}
