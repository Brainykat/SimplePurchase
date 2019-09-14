using HR.Data.EntityConfigurations;
using HR.Domain;
using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HR.Data
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Suffix> Suffixes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("HR");
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new JobTitleConfig());
            modelBuilder.ApplyConfiguration(new JobTypeConfig());
            modelBuilder.ApplyConfiguration(new SuffixConfig());
        }
    }
}
