using RentaCar.Core.Entities.Common;


namespace RentaCar.Core.Entities
{
    public class Car:BaseSectionEntity
    {
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string MainPhotoUrl { get; set; }
        public List<CarPhoto> Photos { get; set; }
        public string Description { get; set; }
        public Guid GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public Guid FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public int SeatCount { get; set; }
        public List<Reservation> Reservations { get; set; }


    }
}
