using Microsoft.AspNetCore.Http;

namespace RentaCar.Business.DTOs.BrandDtos
{
    public record CreateBrandDto(
    string Name,
    IFormFile Icon
);
}
