using RentaCar.Core.Entities;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Interfaces;


namespace RentaCar.DataAccess.Repositories.Implementations
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(RentaCarContext context) : base(context)
        {
        }
    }
}
