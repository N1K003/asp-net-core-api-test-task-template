using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure
{
    public static class InvalidModelStateResponseFactoryProvider
    {
        public static IActionResult InvalidModelStateResponseFactory(ActionContext actionContext)
        {
            var message = string.Join(Environment.NewLine,
                actionContext.ModelState
                    .Where(kvp => kvp.Value.Errors.Any())
                    .SelectMany(x => x.Value.Errors
                        .Select(e => string.IsNullOrEmpty(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage)));

            // TODO throw new ModelValidationException(message);
            throw new NotImplementedException();
        }
    }
}