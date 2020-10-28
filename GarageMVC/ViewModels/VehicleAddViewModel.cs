using GarageMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.ViewModels
{
    public class VehicleAddViewModel
    {
        [Required]
        [Display(Name = "Licence number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Value must be six characters.")]
        public string LicenceNr { get; set; }
        public string Color { get; set; }

        [StringLength(15)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [Range(0, 20, ErrorMessage = "Vehicle must have 0-20 wheels.")]
        [Display(Name = "Number of wheels")]
        public int NrOfWheels { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Time of arrival")]
        public DateTime ArrivalTime { get; set; }


        // Navigation properties

        
        [Display(Name = "Type of vehicle")]
        // public VehicleType2 VehicleType2 { get; set; }
        public int VehicleType2Id { get; set; }
        
    }
}
