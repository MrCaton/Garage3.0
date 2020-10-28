using GarageMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Services
{
    public class MemberSelectService /*: ITypeMemberSelectService*/
    {
        private GarageMVCContext context;


        public MemberSelectService(GarageMVCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> SelectTypes()
        {
            // make sure this picks id, not just name
            return await context.Members.Select(n =>
            new SelectListItem()
            {
                Text = n.UserName,
                Value = n.Id.ToString()
            }).ToListAsync();
        }
    }
}
