using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class UserCardConfiguration : IEntityTypeConfiguration<UserCard>
    {
        public void Configure(EntityTypeBuilder<UserCard> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CardNumber).IsRequired().HasMaxLength(16);
            builder.Property(x => x.ExpireDate).IsRequired(); // stringmi olsun? acabaaa
            builder.Property(x => x.CVV).IsRequired().HasMaxLength(3);
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
