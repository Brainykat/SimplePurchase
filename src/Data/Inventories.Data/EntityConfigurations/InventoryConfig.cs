using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventories.Data.EntityConfigurations
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory.Domain.Entities.Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory.Domain.Entities.Inventory> builder)
        {
            builder.Property(e => e.UserId)
                .IsRequired();
            builder.Property(e => e.PurchaseId)
                .IsRequired();
            builder.Property(e => e.AddedOn)
                .IsRequired();
            builder.Property(e => e.Comments)
                .IsRequired().HasMaxLength(120);
        }
    }
}
