using GarageMVC.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GarageMVC.TagHelpers
{
    [HtmlTargetElement("icon")]
    public class IconTagHelper : TagHelper
    {
        public string vehicleType { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AddClass("icon", HtmlEncoder.Default);

            var icon = "";
            
            var car = "/img/car.svg";
            var motorcycle = "/img/motorcycle.svg";
            var airplane = "/img/airplane.svg";
            var bus = "/img/bus.svg";
            var boat = "/img/boat.svg";

            if (vehicleType == "Car")
            {
               icon = $"<img src='{car}' width='20px';height='20px';>";
            }
            else if (vehicleType == "Motorcycle")
            {
                icon = $"<img src='{motorcycle}' width='20px';height='20px';>";
            }
            else if (vehicleType == "Airplane")
            {
                icon = $"<img src='{airplane}' width='20px';height='20px';>";
            }
            else if (vehicleType == "Bus")
            {
                icon = $"<img src='{bus}' width='20px';height='20px';>";
            }
            else if (vehicleType == "Boat")
            {
                icon = $"<img src='{boat}' width='20px';height='20px';>";
            }

            output.Content.SetHtmlContent(icon);
        }
    }
}
