using RentaCar.Core.Entities;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.DataAccess.Repositories.Implementations
{
	public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(RentaCarContext context) : base(context)
        {
        }
    }
}

