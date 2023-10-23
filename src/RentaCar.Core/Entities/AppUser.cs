using Microsoft.AspNetCore.Identity;

namespace RentaCar.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<CurrentLoaction> CurrentLoactions { get; set; }
        public List<Location> Locations { get; set; }
        public List<UserCard> Cards { get; set; }
        public List<SubscribtionRecord> SubscribtionRecords { get; set; }
    }
}
