using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Role
{
    public class AddRoleModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public RoleViewModel _viewModel { get; set; }
        public AddRoleModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _adminService.AddRole(_viewModel);
                return RedirectToPage("RoleList");
            }
            return Page();
        }
    }
}
