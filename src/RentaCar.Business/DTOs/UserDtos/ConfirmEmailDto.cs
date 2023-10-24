using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.UserDtos
{
    public class ConfirmEmailDto
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
    }
}
