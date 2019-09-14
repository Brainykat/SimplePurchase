
using HR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.EntityConfigurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.SuffixId)
                .IsRequired();
            builder.Property(e => e.JobNumber).IsRequired().HasMaxLength(20);
            builder.OwnsOne(p => p.Name, a =>
            {
                a.Property(p => p.Sur).IsRequired().HasMaxLength(50);
                a.Property(p => p.First).HasMaxLength(50);
                a.Property(p => p.Middle).HasMaxLength(50).HasDefaultValue("");
            });
            builder.Property(e => e.Phone)
                .IsRequired();
            builder.Property(e => e.Email)
                .HasMaxLength(50);
            builder.Property(e => e.GenderId)
                .IsRequired();
            builder.Property(e => e.MaritalStatusId)
                .IsRequired();
            builder.Property(e => e.DOB)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            builder.Property(e => e.IdTypeId)
                .IsRequired();
            builder.Property(e => e.IdNumber)
                .IsRequired().HasMaxLength(20);
            builder.Property(e => e.NationalityId)
                .IsRequired();
            builder.Property(e => e.CountyId)
                .IsRequired();
            builder.Property(e => e.JobTitleId)
                .IsRequired();
            builder.Property(e => e.SecondaryPhone)
                .HasMaxLength(15);
            builder.Property(e => e.JobTypeId)
                .IsRequired();
            builder.Property(e => e.PaymentMode)
                .IsRequired();
            builder.Property(e => e.BranchId)
                .IsRequired();
            builder.Property(e => e.AccountNumber)
                .HasMaxLength(25);
            builder.Property(e => e.HireDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            builder.Property(e => e.KraPin)
                .IsRequired();
            builder.Property(e => e.NHIF)
                .IsRequired();
            builder.Property(e => e.NSSF)
                .IsRequired();
            builder.Property(e => e.PaymentMode)
                .IsRequired();
            builder.OwnsOne(i => i.BasicSalary, f =>
            {
                f.Property(n => n.Currency).IsRequired().HasMaxLength(6);
                f.Property(n => n.Amount).IsRequired();
                f.Property(n => n.Time).IsRequired();
            });
        }
    }
}
