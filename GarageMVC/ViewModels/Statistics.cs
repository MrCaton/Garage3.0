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
        public Dictionary<string, int> NrOfCreatedVehicles { get; set; }

        public int TotalNrOfWheels { get; set; }

        [DataType(DataType.Currency)]
        public int ParkingValuePending { get; set; }

        public int TotalParkedSpots { get; set; }

        public int UnparkedSpots { get; set; }

        public int TotalSpots { get; set; }

        public int ParkedVehicles { get;  set; }
    }
}
