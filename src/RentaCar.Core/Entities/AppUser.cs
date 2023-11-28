using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RentaCar.Core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime CreatedAt { get; set; }
        public string? Fullname { get; set; }
        public string? FinKod { get; set; }
        public string IdentityCard { get; set; }
        public string DriverCard { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool IsConfirmed { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<CurrentLoaction> CurrentLoactions { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<UserCard> Cards { get; set; }
        public IEnumerable<SubscribtionRecord> SubscribtionRecords { get; set; }
    }
}
