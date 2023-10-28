using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.OwnerId).IsRequired();
            builder.Property(x => x.MainPhotoUrl).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.GearBoxId).IsRequired();
            builder.Property(x => x.YearOfManufacture).IsRequired();
            builder.Property(x => x.FuelTypeId).IsRequired();
            builder.Property(x => x.SeatCount).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.EngineVolume).IsRequired().HasMaxLength(3);
        }
    }
}
