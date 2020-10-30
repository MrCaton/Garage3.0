using GarageMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get;  set; }
        public string UserName { get;  set; }
        public string LicenceNr { get;  set; }
        public string VehicleType { get;  set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
