using RentaCar.Core.Entities.Common;


namespace RentaCar.Core.Entities
{
    public class Location:BaseEntity

    {
        public string Name { get; set; }
        public string Adress { get; set; }

        //767687current
        
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } 
        public List<Reservation> Reservation { get; set; }
    }
}
