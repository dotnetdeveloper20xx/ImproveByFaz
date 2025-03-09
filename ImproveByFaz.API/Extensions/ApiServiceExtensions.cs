using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ImproveByFaz.API.Extensions
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //// Add Response Caching Service
            //services.AddResponseCaching();

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379"; // Replace with your Redis Server URL
            //    options.InstanceName = "ImproveByFaz_";
            //});





            // Register Controllers
            services.AddControllers();
            services.AddLogging();

            // Enable Swagger for API Documentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {

                    Title = "ImproveByFaz API",
                    Version = "v1",
                    Description = "API for tracking and improving student learning.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Faz Ahmed",
                        Email = "dotnetdeveloper20xx@hotmail.com",
                        Url = new Uri("https://github.com/dotnetdeveloper20xx/ImproveByFaz")
                    }
                }
                
                );
            });

            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version"); // ✅ Use headers instead of URL
            //});



            // Configure CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            return services;
        }
    }
}
