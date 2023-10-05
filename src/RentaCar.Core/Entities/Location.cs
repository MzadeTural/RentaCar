using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class Location:BaseEntity

    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public Reservation Reservation { get; set; }
    }
}
