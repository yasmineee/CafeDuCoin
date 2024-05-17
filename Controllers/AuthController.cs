
using Microsoft.AspNetCore.Mvc;
using CafeDuCoin.Models;
using CafeDuCoin.Services;

namespace CafeDuCoin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _authService.Authenticate(user.Login, user.Password);
            if (authenticatedUser == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            return Ok(authenticatedUser);
        }
    }
}