using RentaCar.Core.Entities;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.DataAccess.Repositories.Implementations
{
	public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
		public ReservationRepository(RentaCarContext context):base(context)
		{}
	}
}

