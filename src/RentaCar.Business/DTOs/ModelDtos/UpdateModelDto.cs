using System;
namespace RentaCar.Business.DTOs.ModelDtos
{
    public record UpdateModelDto(
    string? Name,
    Guid? BrandId
);
}

