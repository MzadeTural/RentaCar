using RentaCar.Core.Entities.Common;


namespace RentaCar.Core.Entities
{
    public class Reservation:BaseSectionEntity
    {
        public string OwnerId { get; set; }
        public string UserId { get; set; }
        public AppUser User{ get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmetgencyPhoneNumber { get; set; }
        public Guid TakeAwayLoactionId { get; set; }
        public Guid DeliveryLocationId { get; set; }
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
    }
}
