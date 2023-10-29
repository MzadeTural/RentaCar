using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
	{
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.Property(x => x.CarId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
        }
    }
}

