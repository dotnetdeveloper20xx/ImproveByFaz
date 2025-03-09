using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ImproveByFaz.API.Extensions
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
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
