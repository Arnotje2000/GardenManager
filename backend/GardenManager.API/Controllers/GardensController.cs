using GardenManager.Core.Models;
using GardenManager.DTOs.Garden;
using GardenManager.Services.Gardens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GardenManager.API.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
        public class GardensController : ControllerBase
        {
            private readonly IGardenService _gardenService;
            private readonly ILogger<GardensController> _logger;
            public GardensController(IGardenService gardenService,
            ILogger<GardensController> logger)
            {
                _gardenService = gardenService;
                _logger = logger;
            }
            private Guid GetUserId()
            {
                var userIdClaim = User.FindFirst("sub")?.Value;
                return Guid.Parse(userIdClaim);
            }

            /// <summary>
            /// Get all gardens for the authenticated user
            /// </summary>
            [HttpGet]
            public async Task<IActionResult> GetUserGardens()
            {
                try
                {
                    var userId = GetUserId();
                    _logger.LogInformation($"Fetching gardens for user: {userId}");
                    var gardens = await _gardenService.GetUserGardensAsync(userId);
                    return Ok(gardens);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error fetching gardens: {ex.Message}");
                    return BadRequest(new { message = ex.Message });
                }
            }

            /// <summary>
            /// Get a specific garden by ID
            /// </summary>
            [HttpGet("{id}")]
            public async Task<IActionResult> GetGarden(string id)
            {
                try
                {
                    var userId = GetUserId();
                    _logger.LogInformation($"Fetching garden: {id} for user: {userId}");
                    var garden = await _gardenService.GetGardenAsync(Guid.Parse(id), userId);
                    return Ok(garden);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error fetching garden: {ex.Message}");
                    return NotFound(new { message = ex.Message });
                }
            }

            ///<summary>
            /// Create a new garden
            /// </summary>
            [HttpPost]
            public async Task<IActionResult> CreateGarden([FromBody] CreateGardenRequest request)
            {
                try
                {
                    var userId = GetUserId();
                    _logger.LogInformation($"Creating garden for user: {userId}");
                    var garden = await _gardenService.CreateGardenAsync(userId,
                    request);
                    return CreatedAtAction(nameof(GetGarden), new
                    {
                        id = garden.Id
                    }, garden);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error creating garden: {ex.Message}");
                    return BadRequest(new { message = ex.Message });
                }
            }

            /// <summary>
            /// Update an existing garden
            /// </summary>
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateGarden(string id, [FromBody] CreateGardenRequest request)
            {
                try
                {
                    var userId = GetUserId();
                    _logger.LogInformation($"Updating garden: {id} for user: {userId}");
                    var garden = await
                    _gardenService.UpdateGardenAsync(Guid.Parse(id), userId, request);
                    return Ok(garden);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error updating garden: {ex.Message}");
                    return BadRequest(new { message = ex.Message });
                }
            }

            /// <summary>
            /// Delete a garden
            /// </summary>
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteGarden(string id)
            {
                try
                {
                    var userId = GetUserId();
                    _logger.LogInformation($"Deleting garden: {id} for user: {userId}");
                    await _gardenService.DeleteGardenAsync(Guid.Parse(id), userId);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error deleting garden: {ex.Message}");
                    return BadRequest(new { message = ex.Message });
                }
            }
        }
    }
