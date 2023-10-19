using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.Common
{
    public record ResponseDTO(HttpStatusCode httpStatusCode, string Message);
}
