using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class VehicleType2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Range(1,15,ErrorMessage = "Size must be 1 to 15!")]
        public int Size { get; set; }
        

        // Navigation Props
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
