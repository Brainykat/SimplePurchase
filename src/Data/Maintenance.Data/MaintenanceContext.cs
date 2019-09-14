using Maintenance.Data.Configurations;
using Maintenance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Maintenance.Data
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options) : base(options)
        {
        }
        public DbSet<Bank> Banks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Maintenance");
            modelBuilder.ApplyConfiguration(new BankConfig());
            modelBuilder.ApplyConfiguration(new BranchConfig());
        }
    }
}
