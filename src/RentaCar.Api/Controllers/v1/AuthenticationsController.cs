using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.AuthDtos;
using RentaCar.Business.Services.Interfaces;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationsController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginUserDto)
        {
            var response = await _authService.LoginAsync(loginUserDto, 15);
            return Ok(response);
        }

        [HttpPost("refresh-token-login")]
        public async Task<IActionResult> RefreshTokenLogin(string refreshToken)
        {
            var response = await _authService.RefreshTokenLoginAsync(refreshToken);

            return Ok(response);
        }
    }
}
