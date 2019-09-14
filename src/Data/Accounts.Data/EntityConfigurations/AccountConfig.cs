
using Accounts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounts.Data.EntityConfigurations
{
    public class AccountConfig : IEntityTypeConfiguration< Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.OwnsOne(i => i.AccountTransactionLimit, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
            builder.OwnsOne(i => i.AccountNumber, f =>
            {
                f.Property(n => n.COACODE).IsRequired();
                f.Property(n => n.Number).IsRequired();
                f.Property(n => n.BearerCode).IsRequired().HasMaxLength(3);
            });
            builder.Property(e => e.CreatedOn)
                .IsRequired();
            builder.Property(e => e.ChartOfAccountId)
                .IsRequired();
            builder.Property(e => e.Signatories)
                .IsRequired();
        }
    }
}
