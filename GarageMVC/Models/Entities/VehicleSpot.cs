using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class VehicleSpot
    {
        // Foregin Keys
        public int VehicleId { get; set; }
        public int SpotId { get; set; }

        // Navigation props
        public Spot Spot { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
