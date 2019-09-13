using Accounts.Data.EntityConfigurations;
using Accounts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Data
{
    public class AccountsContext : DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
        {
        }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Accounts");
            modelBuilder.ApplyConfiguration(new ChartOfAccountConfig());
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new WalletConfig());
        }
    }
}
