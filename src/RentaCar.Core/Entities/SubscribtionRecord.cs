using System.ComponentModel.DataAnnotations.Schema;
using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class SubscribtionRecord:BaseEntity
    {
        
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid SubscribtionId { get; set; }
        public Subscribtion Subscribtion { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
