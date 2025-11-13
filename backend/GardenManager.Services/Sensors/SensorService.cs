using GardenManager.Core.Models;
using GardenManager.Data.Context;
using GardenManager.DTOs.Sensor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Services.Sensors
{
    public class SensorService : ISensorService
    {
        private readonly ApplicationDbContext _context;
        public SensorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SensorResponse>>
        GetGardenSensorsAsync(Guid gardenId, Guid userId)
        {
            var garden = await _context.Gardens
            .FirstOrDefaultAsync(g => g.Id == gardenId && g.UserId ==
            userId && g.IsActive);
            if (garden == null)
                throw new Exception("Garden not found");
            return await _context.Sensors
            .Where(s => s.GardenId == gardenId && s.Status != "deleted")
            .Select(s => new SensorResponse
            {
                Id = s.Id.ToString(),
                Type = s.Type,
                ExternalId = s.ExternalId,
                Status = s.Status,
                Name = s.Name,
                Description = s.Description,
                LastReadingValue = s.LastReadingValue,
                LastReadingAt = s.LastReadingAt,
                BatteryLevel = s.BatteryLevel,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            })
            .ToListAsync();
        }
        public async Task<SensorResponse> GetSensorAsync(Guid sensorId, Guid
        userId)
        {
            var sensor = await _context.Sensors
            .Include(s => s.Garden)
            .FirstOrDefaultAsync(s => s.Id == sensorId);
            if (sensor == null || sensor.Garden.UserId != userId)
                throw new Exception("Sensor not found");
            return new SensorResponse
            {
                Id = sensor.Id.ToString(),
                Type = sensor.Type,
                ExternalId = sensor.ExternalId,
                Status = sensor.Status,
                Name = sensor.Name,
                Description = sensor.Description,
                LastReadingValue = sensor.LastReadingValue,
                LastReadingAt = sensor.LastReadingAt,
                BatteryLevel = sensor.BatteryLevel,
                CreatedAt = sensor.CreatedAt,
                UpdatedAt = sensor.UpdatedAt
            };
        }
        public async Task<SensorResponse> CreateSensorAsync(Guid gardenId, Guid
        userId, CreateSensorRequest request)
        {
            var garden = await _context.Gardens
            .FirstOrDefaultAsync(g => g.Id == gardenId && g.UserId ==
            userId && g.IsActive);
            if (garden == null)
                throw new Exception("Garden not found");
            // Check if sensor with this external ID already exists
            var existingSensor = await _context.Sensors
            .FirstOrDefaultAsync(s => s.ExternalId == request.ExternalId &&
            s.GardenId == gardenId);
            if (existingSensor != null)
                throw new Exception("Sensor with this external ID already exists in this garden");
                var sensor = new Sensor
                {
                    Id = Guid.NewGuid(),
                    GardenId = gardenId,
                    Type = request.Type,
                    ExternalId = request.ExternalId,
                    Name = request.Name ?? $"{request.Type.ToUpper()} Sensor",
                    Description = request.Description,
                    Status = "active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
            if (!string.IsNullOrEmpty(request.GardenPlotId) &&
            Guid.TryParse(request.GardenPlotId, out var plotId))
            {
                var plot = await _context.GardenPlots.FirstOrDefaultAsync(p =>
                p.Id == plotId && p.GardenId == gardenId);
                if (plot != null)
                {
                    sensor.GardenPlotId = plotId;
                }
            }
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
            return new SensorResponse
            {
                Id = sensor.Id.ToString(),
                Type = sensor.Type,
                ExternalId = sensor.ExternalId,
                Status = sensor.Status,
                Name = sensor.Name,
                Description = sensor.Description,
                LastReadingValue = sensor.LastReadingValue,
                LastReadingAt = sensor.LastReadingAt,
                BatteryLevel = sensor.BatteryLevel,
                CreatedAt = sensor.CreatedAt,
                UpdatedAt = sensor.UpdatedAt
            };
        }
        public async Task<SensorResponse> UpdateSensorAsync(Guid sensorId, Guid
        userId, CreateSensorRequest request)
        {
            var sensor = await _context.Sensors
            .Include(s => s.Garden)
            .FirstOrDefaultAsync(s => s.Id == sensorId);
            if (sensor == null || sensor.Garden.UserId != userId)
                throw new Exception("Sensor not found");
            sensor.Name = request.Name ?? sensor.Name;
            sensor.Description = request.Description ?? sensor.Description;
            sensor.UpdatedAt = DateTime.UtcNow;
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();
            return new SensorResponse
            {
                Id = sensor.Id.ToString(),
                Type = sensor.Type,
                ExternalId = sensor.ExternalId,
                Status = sensor.Status,
                Name = sensor.Name,
                Description = sensor.Description,
                LastReadingValue = sensor.LastReadingValue,
                LastReadingAt = sensor.LastReadingAt,
                BatteryLevel = sensor.BatteryLevel,
                CreatedAt = sensor.CreatedAt,
                UpdatedAt = sensor.UpdatedAt
            };
        }
        public async Task DeleteSensorAsync(Guid sensorId, Guid userId)
        {
            var sensor = await _context.Sensors
            .Include(s => s.Garden)
            .FirstOrDefaultAsync(s => s.Id == sensorId);
            if (sensor == null || sensor.Garden.UserId != userId)
                throw new Exception("Sensor not found");
            sensor.Status = "deleted";
            sensor.UpdatedAt = DateTime.UtcNow;
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SensorReadingResponse>>
        GetSensorReadingsAsync(Guid sensorId, Guid userId, string range = "24h")
        {
            var sensor = await _context.Sensors
            .Include(s => s.Garden)
            .FirstOrDefaultAsync(s => s.Id == sensorId);
            if (sensor == null || sensor.Garden.UserId != userId)
                throw new Exception("Sensor not found");
            var startDate = range switch
            {
                "7d" => DateTime.UtcNow.AddDays(-7),
                "30d" => DateTime.UtcNow.AddDays(-30),
                "90d" => DateTime.UtcNow.AddDays(-90),
                _ => DateTime.UtcNow.AddHours(-24)
            };
            return await _context.SensorReadings
            .Where(r => r.SensorId == sensorId && r.Timestamp >= startDate)
            .OrderByDescending(r => r.Timestamp)
            .Select(r => new SensorReadingResponse
            {
                Id = r.Id.ToString(),
                SensorId = r.SensorId.ToString(),
                Value = r.Value,
                Unit = r.Unit,
                Timestamp = r.Timestamp
            })
            .ToListAsync();
        }
        public async Task<SensorReadingResponse> SubmitSensorReadingAsync(Guid
        sensorId, Guid userId, double value)
        {
            var sensor = await _context.Sensors
            .Include(s => s.Garden)
            .FirstOrDefaultAsync(s => s.Id == sensorId);
            if (sensor == null || sensor.Garden.UserId != userId)
                throw new Exception("Sensor not found");
            // Validate value ranges
            if (sensor.Type == "moisture" && (value < 0 || value > 100))
                throw new Exception("Moisture value must be between 0 and 100");
        if (sensor.Type == "temperature" && (value < -50 || value > 150))
                throw new Exception("Temperature value must be between -50 and 150");
                var reading = new SensorReading
                {
                    Id = Guid.NewGuid(),
                    SensorId = sensorId,
                    Value = value,
                    Unit = sensor.Type == "moisture" ? "%" : "°C",
                    Timestamp = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };
            sensor.LastReadingValue = value;
            sensor.LastReadingAt = DateTime.UtcNow;
            sensor.UpdatedAt = DateTime.UtcNow;
            _context.SensorReadings.Add(reading);
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();
            return new SensorReadingResponse
            {
                Id = reading.Id.ToString(),
                SensorId = reading.SensorId.ToString(),
                Value = reading.Value,
                Unit = reading.Unit,
                Timestamp = reading.Timestamp
            };
        }
    }
}
