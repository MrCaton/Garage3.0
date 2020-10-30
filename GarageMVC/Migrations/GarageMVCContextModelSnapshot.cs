﻿// <auto-generated />
using System;
using GarageMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GarageMVC.Migrations
{
    [DbContext(typeof(GarageMVCContext))]
    partial class GarageMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GarageMVC.Models.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bill@gmail.com",
                            FirstName = "Billy",
                            LastName = "Buch",
                            UserName = "BBch"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ivan@gmail.com",
                            FirstName = "Ivan",
                            LastName = "Araque",
                            UserName = "MrCaton"
                        },
                        new
                        {
                            Id = 3,
                            Email = "david@gmail.com",
                            FirstName = "David",
                            LastName = "Nokto",
                            UserName = "D.Nokto"
                        },
                        new
                        {
                            Id = 4,
                            Email = "mats@gmail.com",
                            FirstName = "Mats",
                            LastName = "Nilsson",
                            UserName = "Matslearning"
                        });
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpotNr")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenceNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<int>("VehicleType2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VehicleType2Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2020, 10, 23, 13, 26, 36, 979, DateTimeKind.Local).AddTicks(6786),
                            Brand = "Opel",
                            Color = "Green",
                            LicenceNr = "CARBBC",
                            MemberId = 1,
                            Model = "Corsa",
                            NrOfWheels = 4,
                            VehicleType2Id = 2
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2020, 10, 25, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8037),
                            Brand = "Volvo",
                            Color = "Black",
                            LicenceNr = "NAVI94",
                            MemberId = 2,
                            Model = "XC90",
                            NrOfWheels = 4,
                            VehicleType2Id = 2
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2020, 10, 28, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8196),
                            Brand = "Yamaha",
                            Color = "Black",
                            LicenceNr = "SKTHMH",
                            MemberId = 3,
                            Model = "Super",
                            NrOfWheels = 2,
                            VehicleType2Id = 1
                        },
                        new
                        {
                            Id = 4,
                            ArrivalTime = new DateTime(2020, 10, 29, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8211),
                            Brand = "Mercedes",
                            Color = "Blue",
                            LicenceNr = "BUSBUS",
                            MemberId = 4,
                            Model = "Ultra",
                            NrOfWheels = 10,
                            VehicleType2Id = 3
                        });
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.VehicleType2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleType2s");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Motorcycle",
                            Size = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Car",
                            Size = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bus",
                            Size = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Airplane",
                            Size = 3
                        });
                });

            modelBuilder.Entity("GarageMVC.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenceNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<int>("StartLocation")
                        .HasColumnType("int");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.Spot", b =>
                {
                    b.HasOne("GarageMVC.Models.Entities.Vehicle", "Vehicle")
                        .WithMany("Spots")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.Vehicle", b =>
                {
                    b.HasOne("GarageMVC.Models.Entities.Member", "Member")
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageMVC.Models.Entities.VehicleType2", "VehicleType2")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleType2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
