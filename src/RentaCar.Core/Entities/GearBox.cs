using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class GearBox:BaseEntity
    {
        public string Name { get; set; }
        public Car Car { get; set; }
    }
}
