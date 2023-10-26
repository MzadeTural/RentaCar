using RentaCar.Business.DTOs;
using RentaCar.Business.DTOs.AuthDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto model, int accessTokenLifeTime);
        Task<TokenResponseDto> RefreshTokenLoginAsync(string refreshToken);
        Task<ConfirmEmailResponseDto> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto);
    }
}
