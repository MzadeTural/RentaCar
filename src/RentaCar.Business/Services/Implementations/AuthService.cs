using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentaCar.Business.DTOs;
using RentaCar.Business.DTOs.AuthDtos;
using RentaCar.Business.DTOs.UserDtos;
using RentaCar.Business.Exceptions.AuthExceptions;
using RentaCar.Business.Exceptions.AuthExceptions.Token;
using RentaCar.Business.Exceptions.UserExceptions;
using RentaCar.Business.Helpers.Extensions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using System.Net;

namespace RentaCar.Business.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(ITokenHandler tokenHandler, IUserService userService, IMailService mailService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _tokenHandler = tokenHandler;
            _userService = userService;
            _mailService = mailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ConfirmEmailResponseDto> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto)
        {
            confirmEmailDto.Token.ThrowIfNullOrWhiteSpace(message: "Token cannot be null");            
            confirmEmailDto.Email.ThrowIfNullOrWhiteSpace(message: "Email cannot be null");

            var user = await _userManager.FindByEmailAsync(confirmEmailDto.Email);
            if (user is null)
                throw new UserNotFoundException($"User not found by email: {confirmEmailDto.Email}", HttpStatusCode.BadRequest);

            if (await _userManager.IsEmailConfirmedAsync(user))
                throw new EmailConfirmationException("This account already activated");

            var result = await _userManager.ConfirmEmailAsync(user, confirmEmailDto.Token);
            if (!result.Succeeded)
                throw new EmailConfirmationException(result.Errors);

            return new(true, $"User successfully activated. Username: {user.UserName}");
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto model, int accessTokenLifeTime)
        {


            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user is null)
                throw new AuthenticationFailException();
            if (!await _userManager.IsEmailConfirmedAsync(user))
                throw new EmailNotConfirmedException();
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {

                var tokenResponse = await GenerateJwtTokenAsync(user, accessTokenLifeTime);

                return new()
                {
                    TokenResponse = tokenResponse
                };
            }
            throw new AuthenticationFailException();
        }
        public async Task<TokenResponseDto> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user is null)
                throw new UserNotFoundException("User not found");

            if (user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                return await GenerateJwtTokenAsync(user, 2);
            }

            throw new RefreshTokenExpiredException();
        }
        private async Task<TokenResponseDto> GenerateJwtTokenAsync(AppUser user, int accessTokenLifeTime)
        {
            var tokenResponse = await _tokenHandler.CreateAccessTokenAsync(accessTokenLifeTime, user);
            await _userService.UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.Expiration, 2);
            return tokenResponse;
        }
    }
}
