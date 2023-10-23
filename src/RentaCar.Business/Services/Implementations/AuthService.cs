using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentaCar.Business.DTOs;
using RentaCar.Business.DTOs.AuthDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Exceptions.AuthExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RentaCar.Business.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AuthService(ITokenHandler tokenHandler, IUserService userService, IMailService mailService,UserManager<AppUser> userManager)
        {
            _tokenHandler = tokenHandler;
            _userService = userService;
            _mailService = mailService;
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto model, int accessTokenLifeTime)
        {


            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName==model.UserName);
            if (user == null)
                throw new AuthenticationFailException();
            var tokenResponse = await GenerateJwtTokenAsync(user, accessTokenLifeTime);

            return new()
            {    
                TokenResponse = tokenResponse
            };
        }

        private async Task<TokenResponseDto> GenerateJwtTokenAsync(AppUser user, int accessTokenLifeTime)
        {
            var tokenResponse = await _tokenHandler.CreateAccessTokenAsync(accessTokenLifeTime, user);
            await _userService.UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.Expiration, 2);
            return tokenResponse;
        }
    }
}
