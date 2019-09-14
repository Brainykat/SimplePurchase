using Inventories.Data.EntityConfigurations;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inventories.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }
        public DbSet<Inventory.Domain.Entities.Inventory> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Inventory");
            modelBuilder.ApplyConfiguration(new InventoryConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
        }
    }
}
