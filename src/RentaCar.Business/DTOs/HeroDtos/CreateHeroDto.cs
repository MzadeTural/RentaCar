using Microsoft.AspNetCore.Http;

namespace RentaCar.Business.DTOs.HeroDtos
{
    public record CreateHeroDto(
        IFormFile Image
        );
}
