using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;
using RentaCar.Core.Entities.Common;
using RentaCar.DataAccess.Configurations;

namespace RentaCar.DataAccess.Contexts
{
    public class RentaCarContext: IdentityDbContext<AppUser>
    {
        public RentaCarContext(DbContextOptions<RentaCarContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new FullTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GearBoxConfiguration());
            modelBuilder.ApplyConfiguration(new HeroConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribtionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribtionRecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserCardConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseSectionEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {

                    case EntityState.Modified:
                        entry.Entity.UptadetAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = "admin";
                        break;
                    case EntityState.Added:
                        entry.Entity.UptadetAt = DateTime.UtcNow;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy="admin";
                        entry.Entity.UpdatedBy="admin";
                        break;


                    default:
                        break;
                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
