using ECommerce.Core.Data;
using ECommerce.Core.Domain;
using ECommerce.Core.Infrastructure;
using ECommerce.Services.Logging;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Mvc;
using ECommerce.Web.Framework.Themes;
using FluentValidation.Mvc;
using StackExchange.Profiling.Mvc;
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
            bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();
            if (databaseInstalled)
            {
                //移除所有视图引擎
                ViewEngines.Engines.Clear();
                ViewEngines.Engines.Add(new ThemeableRazorViewEngine());
            }

            //实现默认的ModelMetadataProvider。添加一些功能
            ModelMetadataProviders.Current = new EMetadataProvider();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // fluent vialidation验证
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new EValidatorFactory()));

            //启动计划任务
            if (databaseInstalled)
            {

            }

            //小型探查器
            if (databaseInstalled)
            {
                if (EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore)
                {
                    GlobalFilters.Filters.Add(new ProfilingActionFilter());
                }
            }

            //日志应用启动
            if (databaseInstalled)
            {
                try
                {
                    var logger = EngineContext.Current.Resolve<ILogger>();
                    logger.Information("应用程序启动", null, null);
                }
                catch (Exception)
                {
                    //异常发生，不抛出新异常。

                }
            }

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

    }
}
