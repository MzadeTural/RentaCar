using System.Net;

namespace RentaCar.Business.DTOs.Common
{
    public record ResponseDTO(HttpStatusCode httpStatusCode, string Message);
}
