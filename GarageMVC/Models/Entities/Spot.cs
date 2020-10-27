using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class Spot
    {
        public int Id { get; set; }
        //public int Nr { get; set; }

        //Navigation Props
        public ICollection<VehicleSpot> VehicleSpots { get; set; }

    }
}
