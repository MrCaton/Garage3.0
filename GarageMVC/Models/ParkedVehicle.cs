using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static AutoMapper.Internal.ExpressionFactory;

namespace GarageMVC.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type of vehicle")]
        public VehicleType VehicleType { get; set; }

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

        [DisplayName("Parking Spot")]
        public int StartLocation { get; set; }

        //KEYS
        //public int Id { get; set; }

        //Navigation
        //public Member Member { get; set; }
    }
}
