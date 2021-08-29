using System.Reflection;
using System.Text.Json.Serialization;
using AspNetCoreApiTestTemplate.Data.Queries;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure.Extensions;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure.Middleware;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure.ModelBinders;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreApiTestTemplate.WebApi
{
    public class Startup
    {
        private const string SwaggerApiName = "API";

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore(options =>
                {
                    options.ModelBinderProviders.Insert(0, new CommaSeparatedIntegersBinderProvider());
                })
                .AddApiExplorer()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    fv.DisableDataAnnotationsValidation = true;
                });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Insert(0, new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
            services.AddResponseCaching();
            services.AddMediatR(typeof(GetUserQuery).GetTypeInfo().Assembly);

            services.Configure<ForwardedHeadersOptions>(options => options.ForwardedHeaders = ForwardedHeaders.All);
            services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
                apiBehaviorOptions.InvalidModelStateResponseFactory = InvalidModelStateResponseFactoryProvider.InvalidModelStateResponseFactory
            );

            services.AddSwagger(SwaggerApiName);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseForwardedHeaders();
            }
            else
            {
                app.UseForwardedHeaders();
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseSwaggerAndConfigure(SwaggerApiName);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}