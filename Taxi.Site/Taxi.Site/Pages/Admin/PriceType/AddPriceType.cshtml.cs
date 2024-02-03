using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.PriceType
{
    public class AddPriceTypeModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public PriceTypeViewModel _viewModel { get; set; }
        public AddPriceTypeModel(IAdminService adminService)
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
                _adminService.AddPriceType(_viewModel);
                return RedirectToPage("PriceTypeList");
            }
            return Page();
        }
    }
}
