using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!storeContext.Books!.Any())
            {
                var booksData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/books.json");
                var books = JsonSerializer.Deserialize<List<Book>>(booksData);

                if (books is not null)
                {
                    foreach (var item in books)
                        storeContext.Books?.Add(item);

                    await storeContext.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<StoreContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}