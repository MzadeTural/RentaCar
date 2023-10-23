using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;


namespace RentaCar.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        public Task<bool> CreateBlogAsync(CreateCarDto blog)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBlogAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> LoadMore(int page)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBlogAsync(string id, UpdateCarDto blog)
        {
            throw new NotImplementedException();
        }
    }
}
