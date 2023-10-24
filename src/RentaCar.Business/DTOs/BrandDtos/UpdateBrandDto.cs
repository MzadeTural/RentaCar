using Microsoft.AspNetCore.Http;

namespace RentaCar.Business.DTOs.BrandDtos
{
    public record UpdateBrandDto(
    string? Name,
    IFormFile? Icon
);
}
