using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities.Common;

namespace RentaCar.DataAccess.Contexts
{
    public class RentaCarContext:DbContext
    {
        public RentaCarContext(DbContextOptions<RentaCarContext> options) : base(options) { }





        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseSectionEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {

                    case EntityState.Modified:
                        entry.Entity.UptadetAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = "admin"; //test
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
