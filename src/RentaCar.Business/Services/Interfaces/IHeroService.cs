using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.HeroDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IHeroService
    {
        IQueryable<Hero> GetAll();
        Task<ResponseDTO> CreateHeroAsync(CreateHeroDto hero);
        Task<ResponseDTO> UpdateHeroAsync(Guid id, UpdateHeroDto hero);
        Task<ResponseDTO> DeleteHeroAsync(Guid id);
    }
}
