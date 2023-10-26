using RentaCar.Business.DTOs;
using RentaCar.Business.DTOs.AuthDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.UserDtos;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto model, int accessTokenLifeTime);
        Task<TokenResponseDto> RefreshTokenLoginAsync(string refreshToken);
        Task<ResponseDTO> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto);
    }
}
