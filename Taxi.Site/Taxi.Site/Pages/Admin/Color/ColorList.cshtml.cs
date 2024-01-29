using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.Color
{
    public class IndexModel : PageModel
    {
        private IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.Color> ColorList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ColorList = await _adminService.GetColors();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeleteColor(id);
            return RedirectToPage("ColorList");
        }
    }
}
