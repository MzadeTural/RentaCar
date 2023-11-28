using System;
using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
	public class Status:BaseEntity
	{
		public string Name { get; set; }
		public IEnumerable<Reservation> Reservations { get; set; }
	}
}

