using RentaCar.Business.DTOs.BrandDtos;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IBrandService
    {
        Task<bool> CreateBrandAsync(CreateBrandDto brand);
        Task<bool> UpdateBrandAsync(string id, UpdateBrandDto brand);
        Task<bool> DeleteBrandAsync(string id);
    }
}
