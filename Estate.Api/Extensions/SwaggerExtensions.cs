using Microsoft.OpenApi.Models;

namespace Estate.Api.Extensions
{

    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Estate API",
                    Version = "v1",
                    Description = "API for managing real estate entities."
                });
            });

        }

        public static void UseFromSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estate API v1");
                c.RoutePrefix = string.Empty; // Swagger در مسیر اصلی بالا بیاد
            });
        }
    }
}