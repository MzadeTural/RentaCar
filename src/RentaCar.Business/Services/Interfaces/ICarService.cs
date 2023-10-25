using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
    public interface ICarService
    {

        Task<ResponseDTO> CreateCarAsync(CreateCarDto blog);
        Task<ResponseDTO> UpdateCarAsync(string id, UpdateCarDto blog);
        Task<ResponseDTO> DeleteCarAsync(string id);
        public Task<List<Car>> LoadMore(int page);
    }
}
