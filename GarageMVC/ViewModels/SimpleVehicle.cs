  using GarageMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.ViewModels
{
    public class SimpleVehicle
    {
        public int Id { get; set; }

        [DisplayName("Vehicle Type")]
        public string VehicleType { get; set; }

        [DisplayName("Licence number")]
        public string LicenceNr { get; set; }

        [DisplayName("Time of arrival")]
        public DateTime ArrivalTime { get; set; }

        [DisplayName("Parked time")]
        public int ParkedHours { get; set; }

        [DisplayName("Time of departure")]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [DisplayName("Parking Spot(s)")]
        public string StartLocation { get; set; }
    }
}
