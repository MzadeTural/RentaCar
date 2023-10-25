using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.Common
{
    public class TestDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
