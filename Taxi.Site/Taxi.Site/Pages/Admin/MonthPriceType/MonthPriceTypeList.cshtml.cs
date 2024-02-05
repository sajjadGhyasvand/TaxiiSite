using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.MonthPriceType
{
    public class MonthPriceTypeList : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        public MonthPriceTypeList(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.MonthPriceType> MonthPriceTypelist { get; set; }
        public async Task<IActionResult> OnGet()
        {
            MonthPriceTypelist = await _adminService.GetMonthPriceTypes();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeleteMonthPriceType(id);
            return RedirectToPage("MonthPriceTypeList");
        }
    }
}
