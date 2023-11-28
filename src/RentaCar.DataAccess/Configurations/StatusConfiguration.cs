using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
	{

        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        }
    }
}

