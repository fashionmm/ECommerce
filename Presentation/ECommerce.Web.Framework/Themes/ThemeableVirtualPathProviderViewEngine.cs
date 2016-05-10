using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using ECommerce.Core.Infrastructure;

namespace ECommerce.Web.Framework.Themes
{
    /// <summary>
    /// 主题化视图引擎
    /// </summary>
    public abstract class ThemeableVirtualPathProviderViewEngine : VirtualPathProviderViewEngine
    {
        #region 方法与工具
        protected virtual string GetAreaName(RouteData routeData)
        {
            object result;
            if(routeData.DataTokens.TryGetValue("area",out result)){

                return (result as string);
            }
            return GetAreaName(routeData.Route);

        }

        protected virtual string GetAreaName(RouteBase route)
        {
            var area = route as IRouteWithArea;
            if (area != null)
            {
                return area.Area;
            }

            var route2 = route as Route;
            if ((route2 != null) && (route2.DataTokens != null))
            {
                return (route2.DataTokens["area"] as string);
            }

            return null;
        }

        protected virtual string GetCurrentTheme()
        {
            var themeContext=EngineContext.Current.Resolve<IThemeContext>();
            
            return themeContext.WorkingThemeName;
        }

        protected virtual string CreateCacheKey(string prefix,string name,string controllerName,string areaName,string theme)
        {

        }
        #endregion

        #region 抽象类实现
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            throw new NotImplementedException();
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
