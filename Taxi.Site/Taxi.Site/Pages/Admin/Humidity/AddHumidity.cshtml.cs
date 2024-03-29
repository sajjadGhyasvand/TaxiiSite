using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Humidity
{
    public class AddHumidityModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public PriceMonthViewModel _viewModel { get; set; }
        public AddHumidityModel(IAdminService adminService)
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
                _adminService.AddHumidity(_viewModel);
                return RedirectToPage("HumadityList");
            }
            return Page();
        }
    }
}
