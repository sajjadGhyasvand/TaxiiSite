using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class CreateUserModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public UserViewModel _viewModel { get; set; }
        public CreateUserModel(IAdminService adminService)
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
                _adminService.AddUser(_viewModel);
                return RedirectToPage("UserList");
            }
            return Page();
        }
    }
}
