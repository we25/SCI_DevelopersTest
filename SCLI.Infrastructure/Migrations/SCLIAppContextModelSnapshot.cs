﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCLI.Infrastructure;

#nullable disable

namespace SCLI.Infrastructure.Migrations
{
    [DbContext(typeof(SCLIAppContext))]
    partial class SCLIAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SCLI.Domain.Entities.Lookups.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lk_Department", "Lookup");
                });

            modelBuilder.Entity("SCLI.Domain.Entities.Lookups.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Lk_JobTitle", "Lookup");
                });

            modelBuilder.Entity("SCLI.Domain.Entities.Operation.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BrithDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepatmentId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepatmentId");

                    b.HasIndex("GenderId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("RelegionId");

                    b.ToTable("Op_Employee", "Operation");
                });

            modelBuilder.Entity("SCLI.Domain.Entities.SystemCodes.SystemCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StaticValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SystemCodeTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemCodeTypeId");

                    b.ToTable("SystemCode", "SystemCode");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StaticValue = "Male",
                            SystemCodeTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            StaticValue = "Female",
                            SystemCodeTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            StaticValue = "Single",
                            SystemCodeTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            StaticValue = "Married",
                            SystemCodeTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            StaticValue = "Muslim",
                            SystemCodeTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            StaticValue = "Christian",
                            SystemCodeTypeId = 3
                        },
                        new
                        {
                            Id = 7,
                            StaticValue = "Other",
                            SystemCodeTypeId = 3
                        });
                });

            modelBuilder.Entity("SCLI.Domain.Entities.SystemCodes.SystemCodeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemCodeType", "SystemCode");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gender"
                        },
                        new
                        {
                            Id = 2,
                            Description = "MaritalStatus"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Relegion"
                        });
                });

            modelBuilder.Entity("SCLI.Domain.Entities.Lookups.JobTitle", b =>
                {
                    b.HasOne("SCLI.Domain.Entities.Lookups.Department", "department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("SCLI.Domain.Entities.Operation.Employee", b =>
                {
                    b.HasOne("SCLI.Domain.Entities.Lookups.Department", "department")
                        .WithMany()
                        .HasForeignKey("DepatmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCLI.Domain.Entities.SystemCodes.SystemCode", "genderSystemCode")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCLI.Domain.Entities.Lookups.JobTitle", "jobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCLI.Domain.Entities.SystemCodes.SystemCode", "statusSystemCode")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCLI.Domain.Entities.SystemCodes.SystemCode", "relegionSystemCode")
                        .WithMany()
                        .HasForeignKey("RelegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("genderSystemCode");

                    b.Navigation("jobTitle");

                    b.Navigation("relegionSystemCode");

                    b.Navigation("statusSystemCode");
                });

            modelBuilder.Entity("SCLI.Domain.Entities.SystemCodes.SystemCode", b =>
                {
                    b.HasOne("SCLI.Domain.Entities.SystemCodes.SystemCodeType", "systemCodeType")
                        .WithMany()
                        .HasForeignKey("SystemCodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("systemCodeType");
                });
#pragma warning restore 612, 618
        }
    }
}