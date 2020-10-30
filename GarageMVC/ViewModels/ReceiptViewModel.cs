using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.ViewModels
{
    public class ReceiptViewModel
    {
        public string UserName { get; set; }

        [DisplayName("Licence Number")]
        public string LicenceNr { get; set; }

        [DisplayName("Parking Spot(s)")]
        public string SpotNr { get; set; }
        
        [DisplayName("Time of arrival")]
        public DateTime ArrivalTime { get; set; }

        [DisplayName("Time of departure")]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [DisplayName("Parked time")]
        public int ParkedHours { get; set; }

        

    }
}
