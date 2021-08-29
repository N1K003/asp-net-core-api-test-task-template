using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure.Extensions
{
    public static class StartupSwaggerExtensions
    {
        private static string EntryAssemblyName => Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown";

        public static IServiceCollection AddSwagger(this IServiceCollection services, string appName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(EntryAssemblyName,
                    new OpenApiInfo
                    {
                        Version = "1.0",
                        Title = $"AspNetCoreApiTestTemplate {appName}",
                        Description = $"AspNetCoreApiTestTemplate {appName} developer documentation"
                    });

                c.DescribeAllParametersInCamelCase();

                var xmlDocFile = Path.Combine(AppContext.BaseDirectory, $"{EntryAssemblyName}.xml");
                if (File.Exists(xmlDocFile))
                {
                    c.IncludeXmlComments(xmlDocFile);
                }

                c.OperationFilter<SwaggerOperationFilter>();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerAndConfigure(this IApplicationBuilder app, string appName)
        {
            app.UseSwagger(c => c.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
            {
                if (!httpRequest.Headers.ContainsKey("X-Forwarded-Host"))
                {
                    return;
                }

                var serverUrl = $"{httpRequest.Headers["X-Forwarded-Proto"]}://"
                                + $"{httpRequest.Headers["X-Forwarded-Host"]}/"
                                + $"{httpRequest.Headers["X-Forwarded-Prefix"]}";

                swaggerDoc.Servers = new List<OpenApiServer>
                {
                    new()
                    {
                        Url = serverUrl
                    }
                };
            }));

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"AspNetCoreApiTestTemplate {appName} documentation";
                c.SwaggerEndpoint($"{EntryAssemblyName}/swagger.json", $"AspNetCoreApiTestTemplate {appName}");
                c.DisplayRequestDuration();
                c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Delete);
                c.DocExpansion(DocExpansion.List);
                c.DefaultModelRendering(ModelRendering.Example);
                c.DefaultModelExpandDepth(2);
                c.DefaultModelsExpandDepth(2);
                c.ShowCommonExtensions();
                c.ShowExtensions();
            });

            return app;
        }
    }
}