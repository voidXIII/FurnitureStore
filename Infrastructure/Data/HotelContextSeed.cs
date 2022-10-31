using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class HotelContextSeed
    {
        public static async Task SeedAsync(HotelContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.BookingStatuses.Any())
                {
                    var statusesData = File.ReadAllText("../Infrastructure/Data/SeedData/BookingStatus.json");
                    var statuses = JsonSerializer.Deserialize<List<BookingStatus>>(statusesData);

                    foreach (var item in statuses)
                    {
                        context.BookingStatuses.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.RoomTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/RoomTypes.json");
                    var types = JsonSerializer.Deserialize<List<RoomType>>(typesData);

                    foreach (var item in types)
                    {
                        context.RoomTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Rooms.Any())
                {
                    var roomsData = File.ReadAllText("../Infrastructure/Data/SeedData/Rooms.json");
                    var rooms = JsonSerializer.Deserialize<List<Room>>(roomsData);

                    foreach (var item in rooms)
                    {
                        context.Rooms.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
              
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<HotelContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}