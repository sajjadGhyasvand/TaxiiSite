using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class DriverPropModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public DriverPropViewModel _viewModel { get; set; }
        public SelectList Roles;
        public DriverPropModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var result = await _adminService.GetDriver(id);
            DriverPropViewModel viewModel = new()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NationalCode = result.NationalCOde,
                Tel = result.Tel,
            };
            ViewData["IsError"] =   "false";
            ViewData["IsSuccess"] = "false";

            return Page();
        }
        public async Task<IActionResult> OnPost(Guid id)
        {
            bool status = false;

            status = _adminService.UpdateDriverProp(id, _viewModel);
            if (status)
            {
                ViewData["IsError"] = "false";
                ViewData["IsSuccess"] = "true";
            }
            else
            {
                ViewData["IsError"] = "true";
                ViewData["IsSuccess"] = "false";
            }
            var result = await _adminService.GetDriver(id);
            DriverPropViewModel viewModel = new()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NationalCode = result.NationalCOde,
                Tel = result.Tel,
            };



            return Page();
        }
    }
}
