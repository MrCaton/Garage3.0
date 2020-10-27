using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageMVC.Services
{
    public interface IVehicleTypeSelectService
    {
        Task<IEnumerable<SelectListItem>> SelectTypes();
    }
}