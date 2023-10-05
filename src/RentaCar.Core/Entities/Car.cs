using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class Car:BaseSectionEntity
    {
        public Guid ModelId { get; set; }
        public  string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string MainPhotoUrl { get; set; }
        public List<CarPhoto> Photos { get; set; }
        public string Description { get; set; }
        public Guid GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public Guid FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public int SeatCount { get; set; }


    }
}
