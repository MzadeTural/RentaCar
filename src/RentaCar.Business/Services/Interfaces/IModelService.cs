using System;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IModelService
	{
        IQueryable<Brand> GetAll();
        Task<ResponseDTO> CreateBrandAsync(CreateBrandDto brand);
        Task<ResponseDTO> UpdateBrandAsync(Guid id, UpdateBrandDto brand);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}

