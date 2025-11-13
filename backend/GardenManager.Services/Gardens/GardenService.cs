using GardenManager.Core.Models;
using GardenManager.Data.Context;
using GardenManager.DTOs.Garden;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Services.Gardens
{
    public class GardenService : IGardenService
    {
        private readonly ApplicationDbContext _context;
        public GardenService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GardenResponse>> GetUserGardensAsync(Guid
        userId)
        {
            return await _context.Gardens
            .Where(g => g.UserId == userId && g.IsActive)
            .Select(g => new GardenResponse
            {
                Id = g.Id.ToString(),
                Name = g.Name,
                Description = g.Description,
                Width = g.Width,
                Height = g.Height,
                Latitude = g.Latitude,
                Longitude = g.Longitude,
                SoilType = g.SoilType,
                PlotCount = g.Plots.Count(p => p.IsActive),
                SensorCount = g.Sensors.Count(s => s.Status == "active"),
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt
            })
            .ToListAsync();
        }
        public async Task<GardenResponse> GetGardenAsync(Guid gardenId, Guid
        userId)
        {
            var garden = await _context.Gardens
            .Include(g => g.Plots)
            .Include(g => g.Sensors)
            .FirstOrDefaultAsync(g => g.Id == gardenId && g.UserId ==
            userId && g.IsActive);
            if (garden == null)
                throw new Exception("Garden not found");
            return new GardenResponse
            {
                Id = garden.Id.ToString(),
                Name = garden.Name,
                Description = garden.Description,
                Width = garden.Width,
                Height = garden.Height,
                Latitude = garden.Latitude,
                Longitude = garden.Longitude,
                SoilType = garden.SoilType,
                PlotCount = garden.Plots.Count(p => p.IsActive),
                SensorCount = garden.Sensors.Count(s => s.Status == "active"),
                CreatedAt = garden.CreatedAt,
                UpdatedAt = garden.UpdatedAt
            };
        }
        public async Task<GardenResponse> CreateGardenAsync(Guid userId,
        CreateGardenRequest request)
        {
            var garden = new Garden
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = request.Name,
                Description = request.Description,
                Width = request.Width,
                Height = request.Height,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                SoilType = request.SoilType,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Gardens.Add(garden);
            await _context.SaveChangesAsync();
            return new GardenResponse
            {
                Id = garden.Id.ToString(),
                Name = garden.Name,
                Description = garden.Description,
                Width = garden.Width,
                Height = garden.Height,
                Latitude = garden.Latitude,
                Longitude = garden.Longitude,
                SoilType = garden.SoilType,
                PlotCount = 0,
                SensorCount = 0,
                CreatedAt = garden.CreatedAt,
                UpdatedAt = garden.UpdatedAt
            };
        }
        public async Task<GardenResponse> UpdateGardenAsync(Guid gardenId, Guid
        userId, CreateGardenRequest request)
        {
            var garden = await _context.Gardens
            .FirstOrDefaultAsync(g => g.Id == gardenId && g.UserId ==
            userId && g.IsActive);
            if (garden == null)
                throw new Exception("Garden not found");
            garden.Name = request.Name;
            garden.Description = request.Description;
            garden.Width = request.Width;
            garden.Height = request.Height;
            garden.Latitude = request.Latitude;
            garden.Longitude = request.Longitude;
            garden.SoilType = request.SoilType;
            garden.UpdatedAt = DateTime.UtcNow;
            _context.Gardens.Update(garden);
            await _context.SaveChangesAsync();
            return new GardenResponse
            {
                Id = garden.Id.ToString(),
                Name = garden.Name,
                Description = garden.Description,
                Width = garden.Width,
                Height = garden.Height,
                Latitude = garden.Latitude,
                Longitude = garden.Longitude,
                SoilType = garden.SoilType,
                PlotCount = garden.Plots.Count(p => p.IsActive),
                SensorCount = garden.Sensors.Count(s => s.Status == "active"),
                CreatedAt = garden.CreatedAt,
                UpdatedAt = garden.UpdatedAt
            };
        }
        public async Task<GardenResponse> DeleteGardenAsync(Guid gardenId, Guid userId)
        {
            var garden = await _context.Gardens
                .Include(g => g.Plots)
                .Include(g => g.Sensors)
                .FirstOrDefaultAsync(g => g.Id == gardenId && g.UserId == userId);
            if (garden == null)
                throw new Exception("Garden not found");
            garden.IsActive = false;
            garden.UpdatedAt = DateTime.UtcNow;
            _context.Gardens.Update(garden);
            await _context.SaveChangesAsync();

            return new GardenResponse
            {
                Id = garden.Id.ToString(),
                Name = garden.Name,
                Description = garden.Description,
                Width = garden.Width,
                Height = garden.Height,
                Latitude = garden.Latitude,
                Longitude = garden.Longitude,
                SoilType = garden.SoilType,
                PlotCount = garden.Plots.Count(p => p.IsActive),
                SensorCount = garden.Sensors.Count(s => s.Status == "active"),
                CreatedAt = garden.CreatedAt,
                UpdatedAt = garden.UpdatedAt
            };
        }
    }
}
