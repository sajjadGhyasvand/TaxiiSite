using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Color
{
    public class DeleteColorModel : PageModel
    {
        private IAdminService _adminService;
        public DeleteColorModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet(Guid id)
        {
            bool result = _adminService.DeleteColor(id);
            return RedirectToPage("CarList");
        }
    }
}
