using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GarageMVC.TagHelpers
{
    [HtmlTargetElement("picon")]
    public class ParkingIconHelper : TagHelper
    {
        public bool Status { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AddClass("picon", HtmlEncoder.Default);

            var picon = "";

            var parked = "/img/p.svg";
            var unparked = "/img/notp.svg";
            

            if (Status)
            {
                picon = $"<img src='{parked}' width='20px';height='20px';>";
            }
            else
            {
                picon = $"<img src='{unparked}' width='20px';height='20px';>";
            }
            
            output.Content.SetHtmlContent(picon);
        }


    }
}
