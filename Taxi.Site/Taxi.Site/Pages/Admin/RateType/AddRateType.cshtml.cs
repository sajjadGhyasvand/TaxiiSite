using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.RateType
{
    public class AddRateTypeModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public ColorViewModel _viewModel { get; set; }
        public AddRateTypeModel(IAdminService adminService)
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
                _adminService.AddColor(_viewModel);
                return RedirectToPage("ColorList");
            }
            return Page();
        }
    }
}
