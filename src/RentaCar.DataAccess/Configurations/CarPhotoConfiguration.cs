using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class CarPhotoConfiguration : IEntityTypeConfiguration<CarPhoto>
    {
        public void Configure(EntityTypeBuilder<CarPhoto> builder)
        {
            builder.Property(x => x.Url).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CarId).IsRequired();
        }
    }
}
