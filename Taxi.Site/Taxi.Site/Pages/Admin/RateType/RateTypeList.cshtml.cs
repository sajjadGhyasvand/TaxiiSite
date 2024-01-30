using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.RateType
{
    public class IndexModel : PageModel
    {
        private IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.RateType> RateTypeList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            RateTypeList = await _adminService.GetRateTypes();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeleteRateType(id);
            return RedirectToPage("RateTypeList");
        }
    }
}
