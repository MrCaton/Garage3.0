using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class Spot
    {
        public int Id { get; set; }
        public int SpotNr { get; set; }

        // Foreign Key
        public int? VehicleId { get; set; }

        //Navigation Props
        public Vehicle Vehicle { get; set; }

    }
}
