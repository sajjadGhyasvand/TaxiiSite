using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Temperature
{
    public class AddTemperatureModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public PriceMonthViewModel _viewModel { get; set; }
        public AddTemperatureModel(IAdminService adminService)
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
                _adminService.AddTemperature(_viewModel);
                return RedirectToPage("TemperatureList");
            }
            return Page();
        }
    }
}
