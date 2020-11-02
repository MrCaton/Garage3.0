using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageMVC.Services
{
    public interface ITypeMemberSelectService
    {
        Task<IEnumerable<SelectListItem>> SelectTypes();
        Task<IEnumerable<SelectListItem>> SelectMembers();
        Task<IEnumerable<SelectListItem>> SelectVehicles();

    }
}