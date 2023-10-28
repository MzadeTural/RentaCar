using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class FuelType:BaseEntity
    {
        public string Name { get; set; }
        public Car Car { get; set; }
    }
}
