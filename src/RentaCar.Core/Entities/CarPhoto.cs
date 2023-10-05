using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class CarPhoto:BaseEntity
    {
        public string Url { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
