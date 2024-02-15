using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class EditUserModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public UserViewModel _viewModel { get; set; }
        public SelectList Roles;
        public EditUserModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            /*Guid guid = new Guid(id);*/
            var result  = await _adminService.GetUserById(id);
            var roleList = await _adminService.GetRoles();
            _viewModel = new()
            {
                RoleId = result.RoleId,
                IsActive = result.IsActive,
                UserName = result.UserName,
            };

            Roles = new SelectList(roleList, "Id", "Title", result.RoleId);
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {

            bool result = _adminService.UpdateUser(id, _viewModel);
            if (result)
                return RedirectToPage("UserList");

            return Page();
        }
    }
}
