using Microsoft.OpenApi.Models;

namespace ParfumBD.API
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ParfumBD API",
                    Version = "v1",
                    Description = "API para la gestión de una tienda de perfumes",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name",
                        Email = "your.email@example.com"
                    }
                });
            });
        }
    }
}
