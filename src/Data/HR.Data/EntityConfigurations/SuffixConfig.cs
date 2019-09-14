using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Data.EntityConfigurations
{
    public class SuffixConfig : IEntityTypeConfiguration<Suffix>
    {
        public void Configure(EntityTypeBuilder<Suffix> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
