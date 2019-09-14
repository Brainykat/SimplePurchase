using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purchase.Domain.Entities;

namespace Purchase.Data.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email)
                .IsRequired().HasMaxLength(50);
            builder.Property(e => e.Phone)
                .IsRequired().HasMaxLength(15);
            builder.Property(e => e.BranchId)
                .IsRequired();
            builder.Property(e => e.AccountNumber)
                .IsRequired().HasMaxLength(25);
            builder.Property(e => e.AddedOn)
                .IsRequired();

        }
    }
}

