using System;
using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
	public class FAQ : BaseSectionEntity
    {
		public string FullName { get; set; }
		public string Content { get; set; }
		public int Star { get; set; }
		public string Image { get; set; }
		public string Position { get; set; }
	}
}

