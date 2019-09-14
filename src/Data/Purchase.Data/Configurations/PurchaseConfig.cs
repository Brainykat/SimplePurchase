using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Purchase.Data.Configurations
{
    public class PurchaseConfig : IEntityTypeConfiguration<Domain.Entities.Purchase>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Purchase> builder)
        {
            builder.Property(e => e.UserId)
                .IsRequired();
            builder.Property(e => e.SupplierId)
                .IsRequired();
            builder.Property(e => e.CreatedOn)
                .IsRequired();
            builder.Property(e => e.PurchaseStage)
                .IsRequired();
        }
    }
}
