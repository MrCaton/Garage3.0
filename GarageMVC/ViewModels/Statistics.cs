using GarageMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GarageMVC.ViewModels
{
    public class Statistics
    {
        public int ParkedCars { get; set; }
        public int ParkedMotorcycles { get; set; }
        public int ParkedBuses { get; set; }
        public int ParkedAirplanes { get; set; }
        public int ParkedBoats { get; set; }

        public int TotalNrOfWheels { get; set; }

        [DataType(DataType.Currency)]
        public int ParkingValuePending { get; set; }
        public int ParkedVehicles { get;  set; }
        public int AvailableSlot { get;  set; }
    }
}
