using RentaCar.Business.DTOs.BrandDtos;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IBrandService
    {
        Task<bool> CreateBrandAsync(CreateBrandDto brand);
        Task<bool> UpdateBrandAsync(Guid id, UpdateBrandDto brand);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}
