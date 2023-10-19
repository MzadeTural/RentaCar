using RentaCar.Business.DTOs;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Interfaces
{
    public interface ITokenHandler
    {
        Task<TokenResponseDto> CreateAccessTokenAsync(int second, AppUser user);
        string CreateRefreshToken();
    }
}
