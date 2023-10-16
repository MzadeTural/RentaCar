using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;

namespace RentaCar.DataAccess.Configurations
{
    public class SubscribtionRecordConfiguration : IEntityTypeConfiguration<SubscribtionRecord>
    {
        public void Configure(EntityTypeBuilder<SubscribtionRecord> builder)
        {
            builder.Property(x => x.AppUser).IsRequired();
            builder.Property(x => x.SubscribtionId).IsRequired();
            builder.Property(x => x.PaymentDate).IsRequired();
        }
    }
}
