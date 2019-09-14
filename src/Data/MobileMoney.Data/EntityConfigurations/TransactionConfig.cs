using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileMoney.Domain.Entities;

namespace MobileMoney.Data.EntityConfigurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(e => e.TransactionType)
                .IsRequired();
            builder.Property(e => e.Reference)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(e => e.TxnTime)
                .IsRequired();
            builder.OwnsOne(i => i.Amount, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
        }
    }
}
