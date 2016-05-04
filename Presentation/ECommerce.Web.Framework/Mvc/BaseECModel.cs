using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.Web.Framework.Mvc
{
    /// <summary>
    /// 模型对象基类
    /// </summary>
    [ModelBinder(typeof(ECModelBinder))]
    public partial class BaseECModel
    {
        public BaseECModel()
        {
            this.CustomerProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

        }

        /// <summary>
        /// 开发者可以重写此方法在自定义部分类中，以添加一些自定义的初始化代码到构造函数
        /// </summary>
        protected virtual void PostInitialize()
        {

        }

        /// <summary>
        /// 使用此属性来存储任何自定义值模型
        /// </summary>
        public Dictionary<string, object> CustomerProperties { get; set; }
    }

    public partial class BaseECEntiyModel : BaseECModel
    {
        public virtual int Id { get; set; }
    }
}
