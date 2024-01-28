using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.Car
{
    public class IndexModel : PageModel
    {
        private IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.Car> CarList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            CarList = await _adminService.GetCars();
            return Page();
        }
    }
}
