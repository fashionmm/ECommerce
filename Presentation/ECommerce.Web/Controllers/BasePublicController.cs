using System.Web.Mvc;
using System.Web.Routing;
using ECommerce.Core.Infrastructure;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Controllers;
using ECommerce.Web.Framework.Security;
using ECommerce.Web.Framework.Seo;

namespace ECommerce.Web.Controllers
{
    //[CheckAffiliate]
    //[StoreClosed]
    //[PublicStoreAllowNavigation]
    //[LanguageSeoCode]
    //[NopHttpsRequirement(SslRequirement.NoMatter)]
    //[WwwRequirement]
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual ActionResult InvokeHttp404()
        {
            // 调用目标控制器并通过RouteData。Call target Controller and pass the routeData.
            IController errorController = EngineContext.Current.Resolve<CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Common");
            routeData.Values.Add("action", "PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));

            return new EmptyResult();
        }

    }
}
