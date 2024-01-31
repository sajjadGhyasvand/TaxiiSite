using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.SiteSetting
{
    public class PriceSettingModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public PriceSettingViewModel _viewModel { get; set; }
        public PriceSettingModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet()
        {
            Setting setting = await _adminService.GetSetting();
            _viewModel = new PriceSettingViewModel()
            {
              IsDistancePrice = setting.IsDistancePrice,
              IsWeatherPrice = setting.IsWeatherPrice,
            };
            ViewData["IsSuccess"] = false.ToString();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                bool result = _adminService.UpdatePriceSetting(_viewModel);
                ViewData["IsSuccess"] = result.ToString();
            }
            return RedirectToPage("/Admin/Index");
        }
    }
}
