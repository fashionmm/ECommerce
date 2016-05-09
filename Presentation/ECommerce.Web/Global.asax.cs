using ECommerce.Core.Data;
using ECommerce.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECommerce.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //禁用头标名称"X-AspNetMvc-Version" 
            MvcHandler.DisableMvcResponseHeader = true;

            //Engine上下文初始化E引擎。
            EngineContext.Initialize(false);

            //检查数据库是否安装
           bool databaseInstalled= DataSettingsHelper.DatabaseIsInstalled();
           if (databaseInstalled)
           {
               //移除所有视图引擎
               ViewEngines.Engines.Clear();
               //ViewEngines.Engines.Add();
           }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender,EventArgs e)
        {

        }
    
    }
}
