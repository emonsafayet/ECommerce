using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken=default)
        {
            foreach (var entry in ChangeTracker.Entries<Order>())
            {

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Safayet"; //TODO: Replace with auth server
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Safayet"; //TODO: Replace with auth server
                        break;
                } 
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        } 
    }
}
