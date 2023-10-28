using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class Location:BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public IEnumerable<Reservation> Reservation { get; set; }
    }
}