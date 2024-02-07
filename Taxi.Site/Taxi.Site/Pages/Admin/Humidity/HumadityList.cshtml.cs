using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.Humidity
{
    public class HumadityList : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        public HumadityList(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.Humidity> Humiditylist { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Humiditylist = await _adminService.GetHumidities();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeleteHumidity(id);
            return RedirectToPage("HumadityList");
        }
    }
}
