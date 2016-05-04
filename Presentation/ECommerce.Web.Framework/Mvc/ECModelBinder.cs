using System.Web.Mvc;

namespace ECommerce.Web.Framework.Mvc
{
   public class ECModelBinder:DefaultModelBinder
    {
       public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
       {
           var model= base.BindModel(controllerContext, bindingContext);
           if (model is BaseECModel)
           {
               ((BaseECModel)model).BindModel(controllerContext, bindingContext);
           }
           return model;
       }
    }
}
