using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.SiteSetting
{
    public class AboutSettingModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public AboutSettingViewModel _viewModel { get; set; }
        public AboutSettingModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet()
        {
            Setting setting = await _adminService.GetSetting();
            _viewModel = new AboutSettingViewModel()
            {
                About = setting.About,
            };
            ViewData["IsSuccess"] = false.ToString();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                bool result = _adminService.UpdateaboutSetting(_viewModel);
                ViewData["IsSuccess"] = result.ToString();
            }
            return RedirectToPage("/Admin/Index");
        }
    }
}
