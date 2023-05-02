﻿// <auto-generated />
using System;
using CanariaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CanariaApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230502110657_foreignkeytoapartmentnumber")]
    partial class foreignkeytoapartmentnumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CanariaApi.Models.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentId"));

                    b.Property<string>("Comfort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kvm")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApartmentId");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            ApartmentId = 1,
                            Comfort = "",
                            CreatedDate = new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9078),
                            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            ImageUrl = "",
                            Kvm = 55,
                            Name = "Royal Bungalow",
                            Occupancy = 4,
                            Rate = 200.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ApartmentId = 2,
                            Comfort = "",
                            CreatedDate = new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9197),
                            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            ImageUrl = "",
                            Kvm = 55,
                            Name = "Premium Pool Bungalow",
                            Occupancy = 4,
                            Rate = 300.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ApartmentId = 3,
                            Comfort = "",
                            CreatedDate = new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9200),
                            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            ImageUrl = "",
                            Kvm = 75,
                            Name = "Luxury Pool Bungalow",
                            Occupancy = 4,
                            Rate = 400.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ApartmentId = 4,
                            Comfort = "",
                            CreatedDate = new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9203),
                            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            ImageUrl = "h",
                            Kvm = 90,
                            Name = "Diamond Bungalow",
                            Occupancy = 4,
                            Rate = 550.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ApartmentId = 5,
                            Comfort = "",
                            CreatedDate = new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9207),
                            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            ImageUrl = "",
                            Kvm = 110,
                            Name = "Diamond Pool Bungalow",
                            Occupancy = 4,
                            Rate = 600.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CanariaApi.Models.ApartmentNumber", b =>
                {
                    b.Property<int>("ApartmentNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FkApartmentId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApartmentNo");

                    b.HasIndex("FkApartmentId");

                    b.ToTable("ApartmentNumbers");
                });

            modelBuilder.Entity("CanariaApi.Models.ApartmentNumber", b =>
                {
                    b.HasOne("CanariaApi.Models.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("FkApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });
#pragma warning restore 612, 618
        }
    }
}
