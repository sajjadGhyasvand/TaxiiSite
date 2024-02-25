using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Discount
{
    public class AddDiscountModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public DiscountAdminViewModel _viewModel { get; set; }
        public AddDiscountModel(IAdminService adminService)
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
                _adminService.AddDiscount(_viewModel);
                return RedirectToPage("DiscountList");
            }
            return Page();
        }
    }
}
