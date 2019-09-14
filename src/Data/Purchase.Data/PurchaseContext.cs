using Microsoft.EntityFrameworkCore;
using Purchase.Data.Configurations;
using Purchase.Domain.Entities;

namespace Purchase.Data
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
        }
        public DbSet<Purchase.Domain.Entities.Purchase> Purchases { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Purchase");
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new PurchaseConfig());
        }
    }
}
