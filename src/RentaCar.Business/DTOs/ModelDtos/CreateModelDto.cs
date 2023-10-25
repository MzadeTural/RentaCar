using System;
using Microsoft.AspNetCore.Http;

namespace RentaCar.Business.DTOs.ModelDtos
{
	public record CreateModelDto(
    string Name,
    Guid BrandId
);
}