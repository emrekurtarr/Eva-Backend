﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperTraders.DAL.Repository.Implementation.EntityFramework;

#nullable disable

namespace SuperTraders.DAL.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20230527192719_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperTraders.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5786),
                            FullName = "Emre Kurtar",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5789)
                        },
                        new
                        {
                            CustomerId = 2,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5791),
                            FullName = "Can Avsar",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5792)
                        },
                        new
                        {
                            CustomerId = 3,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5793),
                            FullName = "Ugur Evren",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5793)
                        },
                        new
                        {
                            CustomerId = 4,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5794),
                            FullName = "Kemal Kilicdaroglu",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5794)
                        },
                        new
                        {
                            CustomerId = 5,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5795),
                            FullName = "Tayyip Erdogan",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5796)
                        });
                });

            modelBuilder.Entity("SuperTraders.Entities.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioId"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PortfolioId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            PortfolioId = 1,
                            Balance = 100m,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6737),
                            CustomerId = 1,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6739)
                        },
                        new
                        {
                            PortfolioId = 2,
                            Balance = 90m,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6741),
                            CustomerId = 2,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6742)
                        },
                        new
                        {
                            PortfolioId = 3,
                            Balance = 85m,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6743),
                            CustomerId = 3,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6743)
                        },
                        new
                        {
                            PortfolioId = 4,
                            Balance = 80m,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6744),
                            CustomerId = 4,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6744)
                        },
                        new
                        {
                            PortfolioId = 5,
                            Balance = 75m,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6745),
                            CustomerId = 5,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6746)
                        });
                });

            modelBuilder.Entity("SuperTraders.Entities.Share", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("char(3)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Symbol");

                    b.ToTable("Shares");

                    b.HasData(
                        new
                        {
                            Symbol = "ATP",
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4649),
                            Price = 5m,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4661)
                        },
                        new
                        {
                            Symbol = "EKG",
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4664),
                            Price = 10m,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4664)
                        },
                        new
                        {
                            Symbol = "SIS",
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4665),
                            Price = 15m,
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4666)
                        });
                });

            modelBuilder.Entity("SuperTraders.Entities.Trade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShareSymbol")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("ShareSymbol");

                    b.ToTable("Trades");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7462),
                            Direction = 1,
                            IsActive = true,
                            PortfolioId = 1,
                            Quantity = 2,
                            ShareSymbol = "ATP",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7464)
                        },
                        new
                        {
                            ID = 2,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7466),
                            Direction = 1,
                            IsActive = true,
                            PortfolioId = 2,
                            Quantity = 3,
                            ShareSymbol = "ATP",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7466)
                        },
                        new
                        {
                            ID = 3,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7468),
                            Direction = 1,
                            IsActive = true,
                            PortfolioId = 3,
                            Quantity = 4,
                            ShareSymbol = "EKG",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7468)
                        },
                        new
                        {
                            ID = 4,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7469),
                            Direction = 1,
                            IsActive = true,
                            PortfolioId = 4,
                            Quantity = 2,
                            ShareSymbol = "EKG",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7469)
                        },
                        new
                        {
                            ID = 5,
                            CreatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7470),
                            Direction = 1,
                            IsActive = true,
                            PortfolioId = 5,
                            Quantity = 1,
                            ShareSymbol = "SIS",
                            UpdatedAt = new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7471)
                        });
                });

            modelBuilder.Entity("SuperTraders.Entities.Portfolio", b =>
                {
                    b.HasOne("SuperTraders.Entities.Customer", "Customer")
                        .WithOne("Portfolio")
                        .HasForeignKey("SuperTraders.Entities.Portfolio", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SuperTraders.Entities.Trade", b =>
                {
                    b.HasOne("SuperTraders.Entities.Portfolio", "Portfolio")
                        .WithMany("Trades")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperTraders.Entities.Share", "Share")
                        .WithMany("Trades")
                        .HasForeignKey("ShareSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("Share");
                });

            modelBuilder.Entity("SuperTraders.Entities.Customer", b =>
                {
                    b.Navigation("Portfolio")
                        .IsRequired();
                });

            modelBuilder.Entity("SuperTraders.Entities.Portfolio", b =>
                {
                    b.Navigation("Trades");
                });

            modelBuilder.Entity("SuperTraders.Entities.Share", b =>
                {
                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}