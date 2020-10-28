using GarageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;

namespace GarageMVC.ViewModels
{
    public class VehicleMember
    {
        public int VehicleId { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string UserName { get;  set; }
        public int VehicleCount { get;  set; }

        //KEYS
        public int Id { get; set; }

        //Navigation
        public Member Member { get; set; }
        public ParkedVehicle ParkedVehicle { get; set; }
    }
}
