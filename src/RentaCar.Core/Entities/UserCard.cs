using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class UserCard:BaseSectionEntity
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string CVV { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
