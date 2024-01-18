using System;
using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
	public class Contact:BaseSectionEntity
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Number { get; set; }
		public string Subject { get; set; }
		public int Type { get; set; }
	}
}

