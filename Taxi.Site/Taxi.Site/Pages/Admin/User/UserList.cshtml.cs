using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class UserListModel : PageModel
    {
        private readonly IAdminService _adminService;
        public List<Taxii.DataLayer.Entities.User> UserList { get; set; }
        public UserListModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> OnGet()
        {
            UserList = await _adminService.GetUsers();

            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
             _adminService.DeleteUser(id);
            return RedirectToPage("UserList");
        }
    }
}
