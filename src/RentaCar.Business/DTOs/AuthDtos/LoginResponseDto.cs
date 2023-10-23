using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.AuthDtos
{
    public class LoginResponseDto
    {
        public TokenResponseDto? TokenResponse { get; set; }
    }
}
