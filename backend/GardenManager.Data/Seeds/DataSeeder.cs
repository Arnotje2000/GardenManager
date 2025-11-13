using GardenManager.Core.Models;
using GardenManager.Data;
using GardenManager.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GardenManager.Data.Seeds
{
    public class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            try
            {
                // Seed Users
                if (!context.Users.Any())
                {
                    var users = new List<User>
                    {
                        new User
                        {
                            Id = Guid.NewGuid(),
                            Email = "john@example.com",
                            Name = "John Doe",
                            PasswordHash = HashPassword("password123"),
                            Avatar = "https://api.dicebear.com/7.x/avataaars/svg?seed=John",
                            CreatedAt = DateTime.UtcNow
                        },
                        new User
                        {
                            Id = Guid.NewGuid(),
                            Email = "jane@example.com",
                            Name = "Jane Smith",
                            PasswordHash = HashPassword("password123"),
                            Avatar =
                            "https://api.dicebear.com/7.x/avataaars/svg?seed=Jane",
                            CreatedAt = DateTime.UtcNow
                        }
                    };
                    context.Users.AddRange(users);
                    await context.SaveChangesAsync();
                } 
                // Seed Plants
                    if (!context.Plants.Any())
                        {
                            var plants = new List<Plant>
                            {
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Tomato",
                                    ScientificName = "Solanum lycopersicum",
                                    Type = "vegetable",
                                    SowingMonths = "[3,4,5]",
                                    HarvestMonths = "[6,7,8,9]",
                                    DaysToMaturity = 70,
                                    OptimalTempMin = 18,
                                    OptimalTempMax = 28,
                                    OptimalMoistureMin = 40,
                                    OptimalMoistureMax = 70,
                                    FertilizerRequirements = "{\"nitrogen\": 14,\"phosphorus\": 10, \"potassium\": 18}",
                                    Spacing = 60,
                                    Sunlight = "full-sun",
                                    WaterNeeds = "high",
                                    Description = "Popular garden vegetable, requires warm weather and plenty of sunlight",
                                    ImageUrl = "https://images.unsplash.com/photo-1592841494993-52519f569346?w=400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Lettuce",
                                    ScientificName = "Lactuca sativa",
                                    Type = "vegetable",
                                    SowingMonths = "[2,3,4,8,9,10]",
                                    HarvestMonths = "[4,5,6,10,11,12]",
                                    DaysToMaturity = 45,
                                    OptimalTempMin = 10,
                                    OptimalTempMax = 20,
                                    OptimalMoistureMin = 50,
                                    OptimalMoistureMax = 80,
                                    FertilizerRequirements = "{\"nitrogen\": 15, \"phosphorus\": 8, \"potassium\": 12}",
                                    Spacing = 30,
                                    Sunlight = "partial-shade",
                                    WaterNeeds = "high",
                                    Description = "Cool-season crop, prefers shade in summer",
                                    ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Carrot",
                                    ScientificName = "Daucus carota",
                                    Type = "vegetable",
                                    SowingMonths = "[3,4,5,7,8]",
                                    HarvestMonths = "[6,7,8,9,10,11]",
                                    DaysToMaturity = 70,
                                    OptimalTempMin = 15,
                                    OptimalTempMax = 25,
                                    OptimalMoistureMin = 45,
                                    OptimalMoistureMax = 65,
                                    FertilizerRequirements = "{\"nitrogen\": 10, \"phosphorus\": 12, \"potassium\": 15}",
                                    Spacing = 10,
                                    Sunlight = "full-sun",
                                    WaterNeeds = "medium",
                                    Description = "Root vegetable, requires loose soil for proper growth",
                                    ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                        Id = Guid.NewGuid(),
                                        Name = "Bell Pepper",
                                        ScientificName = "Capsicum annuum",
                                        Type = "vegetable",
                                        SowingMonths = "[2,3,4]",
                                        HarvestMonths = "[7,8,9,10]",
                                        DaysToMaturity = 90,
                                        OptimalTempMin = 20,
                                        OptimalTempMax = 30,
                                        OptimalMoistureMin = 50,
                                        OptimalMoistureMax = 75,
                                        FertilizerRequirements = "{\"nitrogen\": 12, \"phosphorus\": 15, \"potassium\": 16}",
                                        Spacing = 45,
                                        Sunlight = "full-sun",
                                        WaterNeeds = "high",
                                        Description = "Heat-loving plant, requires warm temperatures",
                                        ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                        CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Cucumber",
                                    ScientificName = "Cucumis sativus",
                                    Type = "vegetable",
                                    SowingMonths = "[4,5,6]",
                                    HarvestMonths = "[6,7,8,9]",
                                    DaysToMaturity = 55,
                                    OptimalTempMin = 18,
                                    OptimalTempMax = 28,
                                    OptimalMoistureMin = 60,
                                    OptimalMoistureMax = 85,
                                    FertilizerRequirements = "{\"nitrogen\": 16, \"phosphorus\": 10, \"potassium\": 14}",
                                    Spacing = 30,
                                    Sunlight = "full-sun",
                                    WaterNeeds = "high",
                                    Description = "Climbing plant, requires support structure",
                                    ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Spinach",
                                    ScientificName = "Spinacia oleracea",
                                    Type = "vegetable",
                                    SowingMonths = "[2,3,4,8,9,10]",
                                    HarvestMonths = "[4,5,6,10,11,12]",
                                    DaysToMaturity = 40,
                                    OptimalTempMin = 5,
                                    OptimalTempMax = 20,
                                    OptimalMoistureMin = 55,
                                    OptimalMoistureMax = 75,
                                    FertilizerRequirements = "{\"nitrogen\": 18, \"phosphorus\": 8, \"potassium\": 10}",
                                    Spacing = 15,
                                    Sunlight = "partial-shade",
                                    WaterNeeds = "medium",
                                    Description = "Cold-hardy leafy green, excellent for early spring and fall",
                                    ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Basil",
                                    ScientificName = "Ocimum basilicum",
                                    Type = "herb",
                                    SowingMonths = "[4,5,6]",
                                    HarvestMonths = "[6,7,8,9]",
                                    DaysToMaturity = 30,
                                    OptimalTempMin = 18,
                                    OptimalTempMax = 28,
                                    OptimalMoistureMin = 40,
                                    OptimalMoistureMax = 70,
                                    FertilizerRequirements = "{\"nitrogen\": 12, \"phosphorus\": 8, \"potassium\": 10}",
                                    Spacing = 20,
                                    Sunlight = "full-sun",
                                    WaterNeeds = "medium",
                                    Description = "Aromatic herb, great companion for tomatoes",
                                    ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                    CreatedAt = DateTime.UtcNow
                                },
                                new Plant
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Parsley",
                                    ScientificName = "Petroselinum crispum",
                                    Type = "herb",
                                    SowingMonths = "[3,4,5,8,9]",
                                    HarvestMonths = "[5,6,7,8,9,10,11]",
                                    DaysToMaturity = 70,
                                    OptimalTempMin = 10,
                                    OptimalTempMax = 25,
                                    OptimalMoistureMin = 50,
                                    OptimalMoistureMax = 75,
                                    FertilizerRequirements = "{\"nitrogen\": 14, \"phosphorus\": 8, \"potassium\": 10}",
                                    Spacing = 20,
                                    Sunlight = "partial-shade",
                                    WaterNeeds = "medium",
                                    Description = "Biennial herb, slow to germinate",
                                    ImageUrl = "https://images.unsplash.com/photo-1599599810694 - b5ac4dd37e3b ? w = 400",
                                    CreatedAt = DateTime.UtcNow
                                }
                            };
                            context.Plants.AddRange(plants);
                            await context.SaveChangesAsync();
                    }

                    // Seed Gardens
                    if (!context.Gardens.Any())
                    {
                        var users = context.Users.ToList();
                        var gardens = new List<Garden>
                        {
                            new Garden
                            {
                                Id = Guid.NewGuid(),
                                UserId = users[0].Id,
                                Name = "Front Yard Garden",
                                Description = "Sunny garden in the front yard",
                                Width = 10,
                                Height = 8,
                                Latitude = 52.3676,Longitude = 4.9041,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Garden
                            {
                                Id = Guid.NewGuid(),
                                UserId = users[0].Id,
                                Name = "Backyard Vegetable Garden",
                                Description = "Shaded area in the backyard",
                                Width = 15,
                                Height = 12,
                                Latitude = 52.3676,
                                Longitude = 4.9041,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Garden
                            {
                                Id = Guid.NewGuid(),
                                UserId = users[1].Id,
                                Name = "Urban Garden",
                                Description = "Container garden on apartment balcony",
                                Width = 5,
                                Height = 3,
                                Latitude = 51.5074,
                                Longitude = -0.1278,
                                CreatedAt = DateTime.UtcNow
                            }
                        };
                        context.Gardens.AddRange(gardens);
                        await context.SaveChangesAsync();
                    } 
                    
                    // Seed Garden Plots
                    if (!context.GardenPlots.Any())
                    {
                        var gardens = context.Gardens.ToList();
                        var plants = context.Plants.ToList();
                        var plots = new List<GardenPlot>
                        {
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                PlantId = plants[0].Id, // Tomato
                                X = 1,
                                Y = 1,
                                Width = 2,
                                Height = 2,
                                PlantedDate = DateTime.UtcNow.AddDays(-30),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(40),
                                CreatedAt = DateTime.UtcNow
                            },
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                PlantId = plants[1].Id, // Lettuce
                                X = 4,
                                Y = 1,
                                Width = 2,
                                Height = 1.5,
                                PlantedDate = DateTime.UtcNow.AddDays(-15),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(30),CreatedAt = DateTime.UtcNow
                            },
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                PlantId = plants[2].Id, // Carrot
                                X = 1,
                                Y = 4,
                                Width = 3,
                                Height = 1.5,
                                PlantedDate = DateTime.UtcNow.AddDays(-20),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(50),
                                CreatedAt = DateTime.UtcNow
                            },
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[1].Id,
                                PlantId = plants[3].Id, // Bell Pepper
                                X = 2,
                                Y = 2,
                                Width = 2,
                                Height = 2,
                                PlantedDate = DateTime.UtcNow.AddDays(-45),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(45),
                                CreatedAt = DateTime.UtcNow
                            },
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[1].Id,
                                PlantId = plants[4].Id, // Cucumber
                                X = 5,
                                Y = 2,
                                Width = 2,
                                Height = 3,
                                PlantedDate = DateTime.UtcNow.AddDays(-10),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(45),
                                CreatedAt = DateTime.UtcNow
                            },
                            new GardenPlot
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[2].Id,
                                PlantId = plants[6].Id, // Basil
                                X = 0.5,
                                Y = 0.5,
                                Width = 1,
                                Height = 1,
                                PlantedDate = DateTime.UtcNow.AddDays(-5),
                                ExpectedHarvestDate = DateTime.UtcNow.AddDays(25),
                                CreatedAt = DateTime.UtcNow
                            }
                        };
                        context.GardenPlots.AddRange(plots);
                        await context.SaveChangesAsync();
                    } 
                    
                    //Seed Sensors
                    if (!context.Sensors.Any())
                    {
                        var gardens = context.Gardens.ToList();
                        var plots = context.GardenPlots.ToList(); var sensors = new List<Sensor>
                        {
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                GardenPlotId = plots[0].Id,
                                Type = "moisture",
                                ExternalId = "SENSOR_001",
                                Name = "Tomato Moisture Sensor",
                                Description = "Monitors soil moisture for tomato plot",
                                Status = "active",
                                LastReadingValue = 65,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                GardenPlotId = plots[0].Id,
                                Type = "temperature",
                                ExternalId = "SENSOR_002",
                                Name = "Tomato Temperature Sensor",
                                Description = "Monitors soil temperature for tomato plot",
                                Status = "active",
                                LastReadingValue = 22.5,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                GardenPlotId = plots[1].Id,
                                Type = "moisture",
                                ExternalId = "SENSOR_003",
                                Name = "Lettuce Moisture Sensor",
                                Description = "Monitors soil moisture for lettuce plot",
                                Status = "active",
                                LastReadingValue = 72,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[0].Id,
                                GardenPlotId = plots[1].Id,
                                Type = "temperature",
                                ExternalId = "SENSOR_004",
                                Name = "Lettuce Temperature Sensor",
                                Description = "Monitors soil temperature for lettuce plot",
                                Status = "active",
                                LastReadingValue = 18.0,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[1].Id,GardenPlotId = plots[3].Id,
                                Type = "moisture",
                                ExternalId = "SENSOR_005",
                                Name = "Pepper Moisture Sensor",
                                Description = "Monitors soil moisture for pepper plot",
                                Status = "active",
                                LastReadingValue = 58,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            },
                            new Sensor
                            {
                                Id = Guid.NewGuid(),
                                GardenId = gardens[1].Id,
                                GardenPlotId = plots[3].Id,
                                Type = "temperature",
                                ExternalId = "SENSOR_006",
                                Name = "Pepper Temperature Sensor",
                                Description = "Monitors soil temperature for pepper plot",
                                Status = "active",
                                LastReadingValue = 25.3,
                                LastReadingAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            }
                        };
                        context.Sensors.AddRange(sensors);
                        await context.SaveChangesAsync();
                    } 
                    
                    // Seed Sensor Readings
                    if (!context.SensorReadings.Any())
                    {
                        var sensors = context.Sensors.ToList();
                        var readings = new List<SensorReading>();

                        // Generate readings for the past 7 days
                        foreach (var sensor in sensors)
                        {
                            for (int i = 0; i < 48; i++) // 2 days * 24 hours
                            {
                                var baseValue = sensor.Type == "moisture"
                                    ? 60 + (Math.Sin(i / 24.0) * 15)
                                    : 20 + (Math.Cos(i / 24.0) * 5);
                                readings.Add(new SensorReading
                                {
                                    Id = Guid.NewGuid(),
                                    SensorId = sensor.Id,
                                    Value = baseValue + (new Random(i).NextDouble() - 0.5) * 5,
                                    Unit = sensor.Type == "moisture" ? "%" : "°C",
                                    Timestamp = DateTime.UtcNow.AddHours(-i),
                                    CreatedAt = DateTime.UtcNow.AddHours(-i)
                                });
                            }
                        }
                        context.SensorReadings.AddRange(readings);
                        await context.SaveChangesAsync();
                    }
                    
                    // Seed Plant Companions
                    if (!context.PlantCompanions.Any())
                    {
                        var plants = context.Plants.ToList();
                        var tomato = plants.FirstOrDefault(p => p.Name ==
                        "Tomato");
                        var basil = plants.FirstOrDefault(p => p.Name == "Basil");
                        var lettuce = plants.FirstOrDefault(p => p.Name ==
                        "Lettuce");
                        var carrot = plants.FirstOrDefault(p => p.Name ==
                        "Carrot");
                        var companions = new List<PlantCompanion>
                        {
                            new PlantCompanion
                            {
                                Id = Guid.NewGuid(),
                                PlantAId = tomato.Id,
                                PlantBId = basil.Id,
                                Compatibility = "good",
                                Notes = "Basil repels insects and improves tomato flavor"
                            },
                            new PlantCompanion
                            {
                                Id = Guid.NewGuid(),
                                PlantAId = tomato.Id,
                                PlantBId = carrot.Id,
                                Compatibility = "good",
                                Notes = "Carrots don't compete for nutrients"
                            },
                            new PlantCompanion
                            {
                                Id = Guid.NewGuid(),
                                PlantAId = lettuce.Id,
                                PlantBId = carrot.Id,
                                Compatibility = "good",
                                Notes = "Both are cool-season crops"
                            }
                        };
                        context.PlantCompanions.AddRange(companions);
                        await context.SaveChangesAsync();
                    }
                    Console.WriteLine("Database seeding completed successfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error seeding database: {ex.Message}");
                throw;
            }
                                } 
        private static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes =
                sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}