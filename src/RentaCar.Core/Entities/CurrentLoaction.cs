

using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class CurrentLoaction:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid CarId { get; set; }
        public Car Car{ get; set; }
        public string Location { get; set; }
    }
}
