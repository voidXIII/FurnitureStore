using System.Text.Json;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class FurnitureStoreSeed
    {
        public static async Task SeedAsync(FurnitureStoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Topologies.Any())
                {
                    var topologyData = File.ReadAllText("../Infrastructure/Data/SeedData/Topology.json");
                    var topology = JsonSerializer.Deserialize<List<Topology>>(topologyData);

                    foreach (var item in topology)
                    {
                        context.Topologies.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Functions.Any())
                {
                    var functionData = File.ReadAllText("../Infrastructure/Data/SeedData/Functions.json");
                    var function = JsonSerializer.Deserialize<List<Function>>(functionData);

                    foreach (var item in function)
                    {
                        context.Functions.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/Products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
              
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<FurnitureStoreSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}