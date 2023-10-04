using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class SubscribtionRecord:BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Subscribtion Subscribtion { get; set; }
        public Guid SubscribtionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
