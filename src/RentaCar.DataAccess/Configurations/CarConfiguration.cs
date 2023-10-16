using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.OwnerId).IsRequired() ;
            builder.Property(x => x.MainPhotoUrl).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.GearBoxId).IsRequired();
            builder.Property(x => x.YearOfManufacture).IsRequired();
            builder.Property(x => x.FuelTypeId).IsRequired();
            builder.Property(x => x.SeatCount).IsRequired();
        }
    }
}
