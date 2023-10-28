using RentaCar.Core.Entities.Common;


namespace RentaCar.Core.Entities
{
    public class Car:BaseSectionEntity
    {
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Price { get; set; }
        public double EngineVolume { get; set; }
        public AppUser Owner { get; set; }
        public string MainPhotoUrl { get; set; }
        public IEnumerable<CarPhoto> Photos { get; set; }
        public string Description { get; set; }
        public Guid GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public Guid FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public int SeatCount { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
