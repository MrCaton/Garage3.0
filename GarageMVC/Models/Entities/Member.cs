using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Models.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Remote(action: "EmailExists", controller: "Remote", HttpMethod = "POST", ErrorMessage = "The email exists")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Remote(action: "UserNameExists", controller: "Remote", HttpMethod = "POST", ErrorMessage = "The user name exists")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        // Foregin Keys
        //public int VehicleType2Id { get; set; }
    }
}
