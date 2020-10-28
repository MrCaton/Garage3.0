using GarageMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Services
{
    public class VehicleTypeSelectService : IVehicleTypeSelectService
    {
        private GarageMVCContext context;
        public VehicleTypeSelectService(GarageMVCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> SelectTypes()
        {
            // make sure this picks id, not just name
            return await context.VehicleType2s.Select(n =>
            new SelectListItem()
            {
                Text = n.Name,
                Value = n.Id.ToString()
            }).ToListAsync();
        }


    }
}
