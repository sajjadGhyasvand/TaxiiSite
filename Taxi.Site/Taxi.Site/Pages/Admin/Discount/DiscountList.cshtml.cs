using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.Discount
{
    public class DiscountListModel : PageModel
    {
        private IAdminService _adminService;

        public DiscountListModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.Discount> DiscountList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            DiscountList = await _adminService.GetDiscounts();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            var result = _adminService.DeleteDiscount(id);
            return RedirectToPage("DiscountList");
        }
    }
}
