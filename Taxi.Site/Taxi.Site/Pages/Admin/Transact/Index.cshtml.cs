using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.Transact
{
    public class IndexModel : PageModel
    {
        private readonly IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IEnumerable<Taxii.DataLayer.Entities.Transact> result { get; set; }
        public async Task<IActionResult> OnGet()
        {
            result = await _adminService.GetTransacts();

            return Page();
        }
    }
}
