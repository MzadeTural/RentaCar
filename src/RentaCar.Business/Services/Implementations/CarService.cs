using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        public Task<ResponseDTO> CreateCarAsync(CreateCarDto blog)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> DeleteCarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> LoadMore(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UpdateCarAsync(string id, UpdateCarDto blog)
        {
            throw new NotImplementedException();
        }
    }
}
