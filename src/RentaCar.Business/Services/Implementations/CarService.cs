using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;


namespace RentaCar.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        public Task<List<Car>> LoadMore(int page)
        {
            throw new NotImplementedException();
        }
    }
}
