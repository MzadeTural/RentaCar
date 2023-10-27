using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
    public interface ICarService
    {

        Task<ResponseDTO> CreateCarAsync(CreateCarDto car);
        Task<ResponseDTO> UpdateCarAsync(string id, UpdateCarDto car);
        Task<ResponseDTO> DeleteCarAsync(string id);
        Task<List<GetUserCarsDto>> GetUserCar(string userId);
        public Task<List<Car>> LoadMore(int page);
    }
}
