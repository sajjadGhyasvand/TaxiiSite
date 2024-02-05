using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.MonthPriceType
{
    public class AddMonthPriceTypeModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public PriceMonthViewModel _viewModel { get; set; }
        public AddMonthPriceTypeModel(IAdminService adminService)
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
                _adminService.AddMonthPriceType(_viewModel);
                return RedirectToPage("MonthPriceTypeList");
            }
            return Page();
        }
    }
}
