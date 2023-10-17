

using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class CurrentLoaction:BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string UserId { get; set; }
        public Guid CarId { get; set; }
        public Car Car{ get; set; }
        public string Location { get; set; }
    }
}
