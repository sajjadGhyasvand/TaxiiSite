using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;

namespace Taxi.Site.Pages.Admin.Temperature
{
    public class TemperatureList : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        public TemperatureList(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public List<Taxii.DataLayer.Entities.Temperature> Humiditylist { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Humiditylist = await _adminService.GetTemperatures();
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            bool result = _adminService.DeleteTemperature(id);
            return RedirectToPage("TemperatureList");
        }
    }
}
