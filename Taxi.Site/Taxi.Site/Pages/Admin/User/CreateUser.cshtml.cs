using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class CreateUserModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public UserViewModel _viewModel { get; set; }
        public SelectList Roles;
        public CreateUserModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> OnGet()
        {
            var roleList = await _adminService.GetRoles();
            Roles = new SelectList(roleList, "Id", "Title");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _adminService.AddUser(_viewModel);
                return RedirectToPage("UserList");
            }
            return Page();
        }
    }
}
