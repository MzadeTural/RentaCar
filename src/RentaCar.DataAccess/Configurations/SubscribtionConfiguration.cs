using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class SubscribtionConfiguration : IEntityTypeConfiguration<Subscribtion>
    {
        public void Configure(EntityTypeBuilder<Subscribtion> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasDefaultValueSql("0");
        }
    }
}
