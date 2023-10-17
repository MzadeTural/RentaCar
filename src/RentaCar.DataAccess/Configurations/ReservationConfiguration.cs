using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.OwnerId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CarId).IsRequired();
            builder.Property(x => x.RentalStartDate).IsRequired();
            builder.Property(x => x.RentalEndDate).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.EmergencyEmail).HasMaxLength(255);
            builder.Property(x => x.EmetgencyPhoneNumber).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TakeAwayLoactionId).IsRequired();
            builder.Property(x => x.DeliveryLocationId).IsRequired();
        }
    }
}
