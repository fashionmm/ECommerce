using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using ECommerce.Core;


namespace ECommerce.Web.Framework.Mvc
{
    /// <summary>
    /// 基于DataAnnotationsModelMetadataProvider之上，实现的一些功能。
    /// 添加自定义属性（实现IModelAttribute）对模型的元数据属性的最高的附加价值，以后可以检索。
    /// </summary>
    public class EMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata= base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            var additionalValues = attributes.OfType<IModelAttribute>().ToList();

            foreach (var additionalValue in additionalValues)
            {
                if (metadata.AdditionalValues.ContainsKey(additionalValue.Name))
                    throw new NopException("There is already an attribute with the name of \"" + additionalValue.Name +
                                               "\" on this model.");
                metadata.AdditionalValues.Add(additionalValue.Name,additionalValue);
            }

            return metadata;
        }
    }
}
