using System;
using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
	public class WishList:BaseSectionEntity
	{
		public Guid AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Guid CarId { get; set; }
		public Car Car { get; set; }
	}
}

