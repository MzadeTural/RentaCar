using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Entities;


namespace RentaCar.DataAccess.Configurations
{
    public class CurrentLoactionConfiguration : IEntityTypeConfiguration<CurrentLoaction>
    {
        public void Configure(EntityTypeBuilder<CurrentLoaction> builder)
        {
            builder.Property(c => c.AppUserId).IsRequired();
            builder.Property(c=>c.CarId).IsRequired();  
            builder.Property(c=>c.Location).IsRequired().HasMaxLength(100);
        }
    }
}
