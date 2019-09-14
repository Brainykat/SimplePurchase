using Accounts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounts.Data.EntityConfigurations
{
    public class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.Property(e => e.AccountId)
            .IsRequired();
            builder.Property(e => e.TxnTime)
            .IsRequired();
            builder.OwnsOne(i => i.Credit, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
            builder.OwnsOne(i => i.Debit, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
            builder.Property(e => e.TxnRefrence)
            .IsRequired();
            builder.Property(e => e.Narration)
            .IsRequired()
            .HasMaxLength(100);
            builder.Property(e => e.TransactingUser)
            .IsRequired();
        }
    }
}
