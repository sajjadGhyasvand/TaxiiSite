using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.PriceType
{
    public class PriceTypeListModel : PageModel
    {
        private IAdminService _adminService;

        public PriceTypeListModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.PriceType> PriceTypeList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            PriceTypeList = await _adminService.GetPriceTypes();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeletePriceType(id);
            return RedirectToPage("PriceTypeList");
        }
    }
}
