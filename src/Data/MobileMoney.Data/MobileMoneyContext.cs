using Microsoft.EntityFrameworkCore;
using MobileMoney.Domain.Entities;

namespace MobileMoney.Data
{
    public class MobileMoneyContext : DbContext
    {
        public MobileMoneyContext(DbContextOptions<MobileMoneyContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("MobileMoney");
        }
    }
}
