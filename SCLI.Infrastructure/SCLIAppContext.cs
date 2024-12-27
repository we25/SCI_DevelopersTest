using Microsoft.EntityFrameworkCore;
using SCLI.Domain.Entities.Lookups;
using SCLI.Domain.Entities.Operation;
using SCLI.Domain.Entities.SystemCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure
{
    public class SCLIAppContext : DbContext
    {
        public SCLIAppContext(DbContextOptions options) : base(options)
        {

        }

        #region LookUps
        public DbSet<Department> departments { get; set; }
        public DbSet<JobTitle> jobTitles { get; set; }
        #endregion

        #region Operation
        public DbSet<Employee> employees { get; set; }
        #endregion

        #region SystemCodes
        public DbSet<SystemCodeType> systemCodeTypes { get; set; }
        public DbSet<SystemCode> systemCodes { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemCodeType>().HasData(
                new SystemCodeType() { Id = 1, Description = "Gender" },
                new SystemCodeType() { Id = 2, Description = "MaritalStatus" },
                new SystemCodeType() { Id = 3, Description = "Relegion" }
                );

            modelBuilder.Entity<SystemCode>().HasData(
                new SystemCode() { Id = 1, StaticValue = "Male", SystemCodeTypeId = 1 },
                new SystemCode() { Id = 2, StaticValue = "Female", SystemCodeTypeId = 1 }
                );
            modelBuilder.Entity<SystemCode>().HasData(
                new SystemCode() { Id = 3, StaticValue = "Single", SystemCodeTypeId = 2 },
                new SystemCode() { Id = 4, StaticValue = "Married", SystemCodeTypeId = 2 }
                );
            modelBuilder.Entity<SystemCode>().HasData(
                new SystemCode() { Id = 5, StaticValue = "Muslim", SystemCodeTypeId = 3 },
                new SystemCode() { Id = 6, StaticValue = "Christian", SystemCodeTypeId = 3 },
                new SystemCode() { Id = 7, StaticValue = "Other", SystemCodeTypeId = 3 }
                );

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.department)
                    .WithMany()
                    .HasForeignKey(e => e.DepatmentId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.jobTitle)
                    .WithMany()
                    .HasForeignKey(e => e.JobTitleId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.genderSystemCode)
                    .WithMany()
                    .HasForeignKey(e => e.GenderId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.statusSystemCode)
                    .WithMany()
                    .HasForeignKey(e => e.MaritalStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.relegionSystemCode)
                    .WithMany()
                    .HasForeignKey(e => e.RelegionId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdateDate").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
