using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.SiteSetting
{
    public class indexModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public SiteSettingViewModel _viewModel { get; set; }
        public indexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet()
        {
            Setting setting = await _adminService.GetSetting();
            _viewModel = new SiteSettingViewModel()
            {
                Desc = setting.Desc,
                Fax = setting.Fax,
                Name = setting.Name,
                Tel = setting.Tel
            };
            ViewData["IsSuccess"] = false.ToString();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                bool result = _adminService.UpdateSiteSetting(_viewModel);
                ViewData["IsSuccess"] = result.ToString();
            }
            return RedirectToPage("/Admin/Index");
        }
    }
}
