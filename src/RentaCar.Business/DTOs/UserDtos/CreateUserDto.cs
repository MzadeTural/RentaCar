using Microsoft.AspNetCore.Http;
using RentaCar.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.UserDtos
{
    public record CreateUserDto(
    string? Fullname,
    string Username,
    string Email,
    IFormFile ImageUrl,
    string PhoneNumber,
    string Password  
);
}
