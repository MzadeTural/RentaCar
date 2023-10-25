using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IBrandService
    {
        IQueryable<Brand> GetAll();
        Task<bool> CreateBrandAsync(CreateBrandDto brand);
        Task<bool> UpdateBrandAsync(Guid id, UpdateBrandDto brand);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}
