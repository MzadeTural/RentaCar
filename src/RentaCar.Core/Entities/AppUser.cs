using Microsoft.AspNetCore.Identity;

namespace RentaCar.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
    }
}
