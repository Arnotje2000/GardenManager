using GardenManager.DTOs.Garden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Services.Gardens
{
    public interface IGardenService
    {
        Task<IEnumerable<GardenResponse>> GetUserGardensAsync(Guid userId);
        Task<GardenResponse> GetGardenAsync(Guid gardenId, Guid userId);
        Task<GardenResponse> CreateGardenAsync(Guid userId, CreateGardenRequest request);
        Task<GardenResponse> UpdateGardenAsync(Guid gardenId, Guid userId, CreateGardenRequest request);
        Task<GardenResponse> DeleteGardenAsync(Guid gardenId, Guid userId);
    }
}
