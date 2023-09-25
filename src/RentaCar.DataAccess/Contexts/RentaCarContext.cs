using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
