using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class VehicleType2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }


        

        // Navigation Props
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
