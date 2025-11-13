using Microsoft.AspNetCore.Mvc;
using GardenManager.Services.Auth;
using GardenManager.DTOs.Auth;

namespace GardenManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController>
        logger)
        {
            _authService = authService;
            _logger = logger;
        } 
        
        /// <summary>
        /// Register a new user
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                _logger.LogInformation($"Registration attempt for email: { request.Email}");
                var response = await _authService.RegisterAsync(request);
                _logger.LogInformation($"User registered successfully: { request.Email}");
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Registration error: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        } 

        /// <summary>
        /// Login user
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                _logger.LogInformation($"Login attempt for email: { request.Email}");
            var response = await _authService.LoginAsync(request);
                _logger.LogInformation($"User logged in successfully: { request.Email}");
            return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login error: {ex.Message}");
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}