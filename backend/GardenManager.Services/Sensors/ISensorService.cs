using GardenManager.DTOs.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Services.Sensors
{
    public interface ISensorService
    {
        Task<IEnumerable<SensorResponse>> GetGardenSensorsAsync(Guid gardenId,
        Guid userId);
        Task<SensorResponse> GetSensorAsync(Guid sensorId, Guid userId);
        Task<SensorResponse> CreateSensorAsync(Guid gardenId, Guid userId,
        CreateSensorRequest request);
        Task<SensorResponse> UpdateSensorAsync(Guid sensorId, Guid userId,
        CreateSensorRequest request);
        Task DeleteSensorAsync(Guid sensorId, Guid userId);
        Task<IEnumerable<SensorReadingResponse>> GetSensorReadingsAsync(Guid
        sensorId, Guid userId, string range = "24h");
        Task<SensorReadingResponse> SubmitSensorReadingAsync(Guid sensorId,
        Guid userId, double value);
    }
}
