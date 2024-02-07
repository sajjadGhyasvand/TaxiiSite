using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Role
{
    public class EditRoleModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public RoleViewModel _viewModel { get; set; }
        public EditRoleModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetRoleById(guid);
            _viewModel = new RoleViewModel()
            {
                Title = result.Title,
                Name = result.Name
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
             
                bool result = _adminService.UpdateRole(id,_viewModel);
                if (result)
                    return RedirectToPage("RoleList");

            return Page();
        }
    }
}
