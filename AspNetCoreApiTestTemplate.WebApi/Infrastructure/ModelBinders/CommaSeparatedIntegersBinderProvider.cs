using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure.ModelBinders
{
    public class CommaSeparatedIntegersBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(ICollection<int>) || context.Metadata.ModelType == typeof(List<int>))
            {
                return new BinderTypeModelBinder(typeof(CommaSeparatedIntegersBinder));
            }

            return null;
        }
    }
}