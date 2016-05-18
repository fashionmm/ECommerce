using ECommerce.Core;
using ECommerce.Core.Data;
using ECommerce.Core.Domain;
using ECommerce.Core.Domain.Common;
using ECommerce.Core.Infrastructure;
using ECommerce.Services.Logging;
using ECommerce.Services.Tasks;
using ECommerce.Web.Controllers;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Mvc;
using ECommerce.Web.Framework.Themes;
using FluentValidation.Mvc;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
                TaskManager.Instance.Initialize();
                TaskManager.Instance.Start();
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
            //忽略静态资源
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if (webHelper.IsStaticResource(this.Request)) return;

            //保持页面请求(防止创建一个来宾客户记录)
            string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            if (webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                return;

            //确保数据库被安装
            if (!DataSettingsHelper.DatabaseIsInstalled())
            {
                string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
                if (!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.Response.Redirect(installUrl);
                }
            }

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //小型探查器
            if (EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore)
            {
                MiniProfiler.Start();
                //存储一个值表示探查器已启动
                HttpContext.Current.Items["e.MiniProfilerStarted"] = true;
            }


        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //探查器
            var miniProfilerStarted = HttpContext.Current.Items.Contains("e.MiniProfilerStarted") &&
                Convert.ToBoolean(HttpContext.Current.Items["e.MiniProfilerStarted"]);
            if (miniProfilerStarted)
            {
                MiniProfiler.Stop();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //
            SetWorkingCulture();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);

            //process 404 HTTP errors
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                if (!webHelper.IsStaticResource(this.Request))
                {
                    Response.Clear();
                    Server.ClearError();
                    Response.TrySkipIisCustomErrors = true;

                    // Call target Controller and pass the routeData.
                    IController errorController = EngineContext.Current.Resolve<Commmon1Controller>();

                    var routeData = new RouteData();
                    routeData.Values.Add("controller", "Common");
                    routeData.Values.Add("action", "PageNotFound");

                    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                }
            }
        }

        protected void SetWorkingCulture()
        {
            if (!DataSettingsHelper.DatabaseIsInstalled()) return;

            //忽略静态资源
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if (webHelper.IsStaticResource(this.Request))
                return;

            //keep alive page requested (we ignore it to prevent creation of guest customer records)
            string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            if (webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                return;

            if (webHelper.GetThisPageUrl(false).StartsWith(string.Format("{0}admin", webHelper.GetStoreLocation()), StringComparison.InvariantCultureIgnoreCase))
            {
                //管理员区域

                CommonHelper.SetTelerikCulture();
            }
            else
            {
                //公共店铺
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                var culture = new CultureInfo(workContext.WorkingLanguage.LanguageCulture);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404 &&
                !EngineContext.Current.Resolve<CommonSettings>().Log404Errors)
                return;

            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                logger.Error(exc.Message, exc, workContext.CurrentCustomer);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }

        
    }
}
