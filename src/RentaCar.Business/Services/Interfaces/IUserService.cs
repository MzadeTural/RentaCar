using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.UserDtos;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDTO> CreateAsync(CreateUserDto model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenEndDate, int refreshTokenLifeTime);
    }
}
