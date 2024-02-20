using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class DriverCertificateModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public DriverimgViewModel _viewModel { get; set; }
        public SelectList Roles;
        public DriverCertificateModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            var driver = await _adminService.GetDriver(id);
            DriverimgViewModel model = new()
            {
                IsConfirm = driver.IsConfirm,
                ImgNAme = driver.CarImg,
            };
            ViewData["IsSuccess"] = "false";
            ViewData["IsError"] = "false";
            return Page();
        }
        public async Task<IActionResult> OnPost(Guid id)
        {
            var driver = await _adminService.GetDriver(id);
            bool result = false;
                _adminService.UpdateDriverCertificated(id, _viewModel);
            if (result)
            {
                ViewData["IsSuccess"] = "true";
                ViewData["IsError"] = "false";
            }
            else
            {
                ViewData["IsSuccess"] = "false";
                ViewData["IsError"] = "true";
            }
            DriverimgViewModel model = new()
            {
                IsConfirm = driver.IsConfirm,
                ImgNAme = driver.CarImg,
            };
            return RedirectToPage("UserList");
        }
    }
}
