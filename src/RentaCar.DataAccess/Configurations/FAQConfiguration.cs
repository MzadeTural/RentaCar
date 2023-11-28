using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Star).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Position).HasMaxLength(20).IsRequired();
        }
    }
}
