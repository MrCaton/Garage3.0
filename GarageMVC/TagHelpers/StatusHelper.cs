using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GarageMVC.TagHelpers
{
    [HtmlTargetElement("parkingstatus")]
    public class StatusHelper : TagHelper
    {
        public bool Status { get; set; }
        public int Key { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AddClass("parkingstatus", HtmlEncoder.Default);

            var parkingstatus = "";




            if (Status)
            {
                //parkingstatus = "links for unparking";

                output.Content.SetHtmlContent(
                $@"<a href=""../Vehicles/Edit/{Key}"">Edit</a>
                   <a href=""../Vehicles/Details/{Key}"">Details</a>
                   <a href=""../Vehicles/Receipt/{Key}"">Unpark</a>"
                   );
            }
            else
            {
                //parkingstatus = "links for parking and deleting";

                output.Content.SetHtmlContent(
                $@"<a href=""../Vehicles/Edit/{Key}"">Edit</a>
                   <a href=""../Vehicles/Details/{Key}"">Details</a>
                   <a href=""../Vehicles/Delete/{Key}"">Delete</a>"
                   );
            }

            
        }


    }
}
