using Microsoft.AspNetCore.Identity;

namespace RentaCar.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Location> Locations { get; set; }
    }
}
