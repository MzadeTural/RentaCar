using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities;
using RentaCar.Core.Entities.Common;
using RentaCar.DataAccess.Configurations;

namespace RentaCar.DataAccess.Contexts
{
    public class RentaCarContext: IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public RentaCarContext(DbContextOptions<RentaCarContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }
        //public DbSet<CurrentLoaction> CurrentLoactions { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Subscribtion> Subscribtions { get; set; }
        public DbSet<SubscribtionRecord> SubscribtionRecords { get; set; }
        public DbSet<UserCard> UserCards { get; set; }



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
            //modelBuilder.ApplyConfiguration(new CurrentLoactionConfiguration());

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubscribtionRecord>()
                .Ignore(e => e.AppUser);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Owner)
            .WithMany()
            .HasForeignKey(r => r.OwnerId);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

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
