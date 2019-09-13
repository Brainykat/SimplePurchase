using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Data.EntityConfigurations
{
    public class ChartOfAccountConfig : IEntityTypeConfiguration<ChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<ChartOfAccount> builder)
        {
            builder.Property(e => e.Number)
                .IsRequired();
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.AccountType)
                .IsRequired();
            builder.Property(e => e.Statement)
                .IsRequired();
        }
    }
}
