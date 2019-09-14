using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Data
{
    public class ReferenceContext : DbContext
    {
        public ReferenceContext(DbContextOptions<ReferenceContext> options) : base(options)
        {
        }
        public DbSet<Branch> Branch { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Maintenance");
        }
    }
}
