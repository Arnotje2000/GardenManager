using GardenManager.Core.Models;
using GardenManager.DTOs.Sensor;
using GardenManager.Services;
using GardenManager.Services.Sensors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GardenManager.API.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorService _sensorService;
        private readonly ILogger<SensorsController> _logger;
        public SensorsController(ISensorService sensorService,
        ILogger<SensorsController> logger)
        {
            _sensorService = sensorService;
            _logger = logger;
        }
        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst("sub")?.Value;
            return Guid.Parse(userIdClaim);
        }

        /// <summary>
        /// Get all sensors for a garden
        /// </summary>
        [HttpGet("garden/{gardenId}")]
        public async Task<IActionResult> GetGardenSensors(string gardenId)
        {
            try
            {
                var userId = GetUserId();
                _logger.LogInformation($"Fetching sensors for garden: { gardenId}");
                var sensors = await
                _sensorService.GetGardenSensorsAsync(Guid.Parse(gardenId), userId);
                return Ok(sensors);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error fetching sensors: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get a specific sensor
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensor(string id)
        {
            try
            {
                var userId = GetUserId();
                var sensor = await _sensorService.GetSensorAsync(Guid.Parse(id), userId);
                return Ok(sensor);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error fetching sensor: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Create a new sensor
        /// </summary>
        [HttpPost("garden/{gardenId}")]
        public async Task<IActionResult> CreateSensor(string gardenId, [FromBody] CreateSensorRequest request)
        {
            try
            {
                var userId = GetUserId();
                _logger.LogInformation($"Creating sensor for garden: { gardenId}");
                var sensor = await _sensorService.CreateSensorAsync(Guid.Parse(gardenId), userId, request);
                return CreatedAtAction(nameof(GetSensor), new {id = sensor.Id}, sensor);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error creating sensor: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Update a sensor
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(string id, [FromBody] CreateSensorRequest request)
        {
            try
            {
                var userId = GetUserId();
                var sensor = await
                _sensorService.UpdateSensorAsync(Guid.Parse(id), userId, request);
                return Ok(sensor);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error updating sensor: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a sensor
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(string id)
        {
            try
            {
                var userId = GetUserId();
                await _sensorService.DeleteSensorAsync(Guid.Parse(id), userId);
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error deleting sensor: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }
        /// <summary>
        /// Get sensor readings
        /// </summary>
        [HttpGet("{id}/readings")]
        public async Task<IActionResult> GetSensorReadings(string id, [FromQuery] string range = "24h")
        {
            try
            {
                var userId = GetUserId();
                var readings = await
                _sensorService.GetSensorReadingsAsync(Guid.Parse(id), userId, range);
                return Ok(readings);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error fetching readings: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        } 
        
        ///<summary>
        /// Submit a new sensor reading
        /// </summary>
        [HttpPost("{id}/readings")]
        public async Task<IActionResult> SubmitSensorReading(string id, [FromBody] SensorReadingRequest request)
        {
            try
            {
                var userId = GetUserId();
                var reading = await
                _sensorService.SubmitSensorReadingAsync(Guid.Parse(id), userId, request.Value);
                return CreatedAtAction(nameof(GetSensorReadings), new { id },
                reading);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error submitting reading: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}


