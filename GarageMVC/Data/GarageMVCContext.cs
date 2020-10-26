 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GarageMVC.Models;


namespace GarageMVC.Data
{
    public class GarageMVCContext : DbContext
    {
        public GarageMVCContext (DbContextOptions<GarageMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkedVehicle>()
                .HasData(
                    new ParkedVehicle { Id = 1, VehicleType = VehicleType.Car, LicenceNr = "BIL111", Brand = "Volkswagen", Color = "Grey", Model = "Golf", NrOfWheels = 4, ArrivalTime =                DateTime.Now.AddDays(-1.0), StartLocation = 0},
                    new ParkedVehicle { Id = 2, VehicleType = VehicleType.Motorcycle, LicenceNr = "MOT111", Brand = "Ducati", Color = "Red", Model = "Retro", NrOfWheels = 2, ArrivalTime =             DateTime.Now.AddDays(-1.0), StartLocation = 1},
                    new ParkedVehicle { Id = 3, VehicleType = VehicleType.Airplane, LicenceNr = "AIR111", Brand = "Boeing", Color = "White", Model = "777", NrOfWheels = 12, ArrivalTime =              DateTime.Now.AddDays(-2.0), StartLocation = 2},
                    new ParkedVehicle { Id = 4, VehicleType = VehicleType.Boat, LicenceNr = "BOA111", Brand = "Bertram", Color = "White", Model = "31 Flybridge Cruiser", NrOfWheels = 0, ArrivalTime = DateTime.Now.AddDays(-3.0), StartLocation = 5},
                    new ParkedVehicle { Id = 5, VehicleType = VehicleType.Bus, LicenceNr = "BUS111", Brand = "Mercedes Benz", Color = "Red", Model = "Citario", NrOfWheels = 4, ArrivalTime =           DateTime.Now.AddDays(-4.0), StartLocation = 8},
                    new ParkedVehicle { Id = 6, VehicleType = VehicleType.Car, LicenceNr = "BIL222", Brand = "Mercedes Benz", Color = "Black", Model = "C-Class", NrOfWheels = 4, ArrivalTime =         DateTime.Now.AddDays(-5.0), StartLocation = 10},
                    new ParkedVehicle { Id = 7, VehicleType = VehicleType.Motorcycle, LicenceNr = "MOT222", Brand = "BMW", Color = "Green", Model = "S 1000 RR", NrOfWheels = 2, ArrivalTime =          DateTime.Now.AddDays(-6.0), StartLocation = 11},
                    new ParkedVehicle { Id = 8, VehicleType = VehicleType.Airplane, LicenceNr = "AIR222", Brand = "SAAB", Color = "Grey", Model = "Gripen", NrOfWheels = 3, ArrivalTime =               DateTime.Now.AddDays(-7.0), StartLocation = 12},
                    new ParkedVehicle { Id = 9, VehicleType = VehicleType.Boat, LicenceNr = "BOA222", Brand = "Sea Ray", Color = "White", Model = "SLX 400 OB", NrOfWheels = 0, ArrivalTime =           DateTime.Now.AddDays(-8.0), StartLocation = 15},
                    new ParkedVehicle { Id = 10, VehicleType = VehicleType.Bus, LicenceNr = "BUS222", Brand = "Man", Color = "Blue", Model = "SR 240", NrOfWheels = 4, ArrivalTime =                    DateTime.Now.AddDays(-9.0), StartLocation = 18}
                    

                );
            modelBuilder.Entity<Member>().HasData(
            new Member { Id = 1, FirstName = "Nelson", LastName = "Mandela", Email = "nelsonmandela@gmail.com", UserName = "Nmandela" }
            );
        }

        //public DbSet<GarageMVC.Models.Member> Member { get; set; }
    }
}
