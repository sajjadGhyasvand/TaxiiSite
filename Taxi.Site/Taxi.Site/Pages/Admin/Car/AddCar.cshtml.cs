using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Car
{
    public class AddCarModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public CarViewModel _viewModel { get; set; }
        public AddCarModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _adminService.AddCar(_viewModel);
                return RedirectToPage("CarList");
            }
            return Page();
        }
    }
}
