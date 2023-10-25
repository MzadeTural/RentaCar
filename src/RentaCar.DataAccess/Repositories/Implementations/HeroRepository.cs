using RentaCar.Core.Entities;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.DataAccess.Repositories.Implementations
{
    public class HeroRepository : Repository<Hero>, IHeroRepository
    {
        public HeroRepository(RentaCarContext context):base(context) { }
    }
}
