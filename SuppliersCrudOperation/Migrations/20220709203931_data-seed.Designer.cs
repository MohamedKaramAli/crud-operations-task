﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuppliersCrudOperation.DAL;

namespace SuppliersCrudOperation.Migrations
{
    [DbContext(typeof(SuppliersDbContext))]
    [Migration("20220709203931_data-seed")]
    partial class dataseed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuppliersCrudOperation.DAL.Entities.Governorate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Governorates");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Cairo",
                            Order = 1
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Alex",
                            Order = 2
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Contractor",
                            Order = 3
                        });
                });

            modelBuilder.Entity("SuppliersCrudOperation.DAL.Entities.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GovernorateId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GovernorateId");

                    b.HasIndex("TypeId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SuppliersCrudOperation.DAL.Entities.SupplierType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SupplierTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Manufacturer"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Importer"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Contractor"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Distriputer"
                        });
                });

            modelBuilder.Entity("SuppliersCrudOperation.DAL.Entities.Supplier", b =>
                {
                    b.HasOne("SuppliersCrudOperation.DAL.Entities.Governorate", "Governorate")
                        .WithMany()
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuppliersCrudOperation.DAL.Entities.SupplierType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governorate");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
