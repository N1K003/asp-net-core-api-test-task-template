using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure.Filters
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("204",
                new OpenApiResponse
                {
                    Description = "NoContent"
                });
            operation.Responses.Add("400",
                new OpenApiResponse
                {
                    Description = "BadRequest"
                });
            operation.Responses.Add("404",
                new OpenApiResponse
                {
                    Description = "NotFound"
                });
            operation.Responses.Add("500",
                new OpenApiResponse
                {
                    Description = "InternalServerError"
                });
        }
    }
}