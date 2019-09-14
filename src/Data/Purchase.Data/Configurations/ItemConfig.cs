using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purchase.Domain.Entities;

namespace Purchase.Data.Configurations
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(e => e.PurchaseId)
                .IsRequired();
            builder.Property(e => e.Name)
                .IsRequired().HasMaxLength(20);
            builder.Property(e => e.Description)
                .IsRequired().HasMaxLength(50);
            builder.Property(e => e.BarCode)
                .IsRequired().HasMaxLength(120);
            builder.Property(e => e.Quantity)
                .IsRequired();
            builder.OwnsOne(i => i.PricePerItem, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
        }
    }
}
