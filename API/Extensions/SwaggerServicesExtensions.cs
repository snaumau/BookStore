using Microsoft.OpenApi.Models;

namespace API.Extensions;

/// <summary>
/// Add swagger documentation to the middleware
/// </summary>
public static class SwaggerServicesExtensions
{
    /// <summary>
    /// Add for the service
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo {Title = "API Documentation", Version = "v1"}));
    }

    /// <summary>
    /// Add for the application builder
    /// </summary>
    /// <param name="app"></param>
    public static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.API");
        });
    }
}