using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class GearBoxConfiguration : IEntityTypeConfiguration<GearBox>
    {
        public void Configure(EntityTypeBuilder<GearBox> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(10);
        }
    }
}
