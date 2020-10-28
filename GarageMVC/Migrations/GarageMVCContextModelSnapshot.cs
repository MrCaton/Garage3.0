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
                            Id = 3,
                            Email = "bill@gmail.com",
                            FirstName = "Billy",
                            LastName = "Buch",
                            UserName = "BBch"
                        });
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

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
                });

            modelBuilder.Entity("GarageMVC.Models.Entities.VehicleSpot", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("SpotId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId", "SpotId");

                    b.HasIndex("SpotId");

                    b.ToTable("VehicleSpots");
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
                            Id = 6,
                            Name = "Motorcycle",
                            Size = 1
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

            modelBuilder.Entity("GarageMVC.Models.Entities.VehicleSpot", b =>
                {
                    b.HasOne("GarageMVC.Models.Entities.Spot", "Spot")
                        .WithMany("VehicleSpots")
                        .HasForeignKey("SpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageMVC.Models.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleSpots")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
