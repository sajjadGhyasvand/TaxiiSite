using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Car
{
    public class DeleteCarModel : PageModel
    {
        private IAdminService _adminService;
        public DeleteCarModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet(Guid id)
        {
            var result = _adminService.DeleteCar(id);
            return RedirectToPage("CarList");
        }
    }
}
