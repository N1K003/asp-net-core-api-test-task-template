using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure.ModelBinders
{
    public class CommaSeparatedIntegersBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // TODO will do it later
            throw new NotImplementedException();
        }
    }
}