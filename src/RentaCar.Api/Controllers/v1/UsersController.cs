using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.UserDtos;
using RentaCar.Business.Enums;
using RentaCar.Business.Services.Implementations;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using System.Net;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;

        public UsersController(IUserService userService, RoleManager<IdentityRole> roleManager, IAuthService authService)
        {
            _userService = userService;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromForm] CreateUserDto createUserDto)
        {
            var response = await _userService.CreateAsync(createUserDto);

            return StatusCode((int)response.httpStatusCode, response.Message);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailDto confirmEmailDto)
        {
            var response = await _authService.ConfirmEmailAsync(confirmEmailDto);
            return StatusCode((int)response.httpStatusCode, response.Message);
        }

        [HttpPost("createrole")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }
    }
}
