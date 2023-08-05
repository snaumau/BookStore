using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

/// <summary>
/// Apply migrations and seeded data if database doesn't exist
/// </summary>
public static class MigrationServicesExtensions
{
    public static async void ApplyMigrations(this WebApplication app)
    {
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var context = serviceProvider.GetRequiredService<StoreContext>();
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsync(context, loggerFactory);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "An error occured during migration");
        }
    }
}