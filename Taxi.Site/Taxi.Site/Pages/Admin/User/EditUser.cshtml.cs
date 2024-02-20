using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Admin.User
{
    public class EditUserModel : PageModel
    {
        private readonly IAdminService _adminService;
        private PersianCalendar pc = new();
        [BindProperty]
        public UserEditViewModel _viewModel { get; set; }
        public SelectList Roles;
        public EditUserModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var result  = await _adminService.GetUserById(id);
            var userDatail = await _adminService.GetUserDetail(id);
            var roleList = await _adminService.GetRoles();
            _viewModel = new()
            {
                RoleId = result.RoleId,
                IsActive = result.IsActive,
                UserName = result.UserName,
                BirthDate = userDatail.BirthDate,
                FullName= userDatail.FullName,
            };
            if (userDatail.BirthDate == null)
            {
                ViewData["MyDate"] = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            }
            else
            {
                ViewData["MyDate"] = userDatail.BirthDate.ToString();
            }
            Roles = new SelectList(roleList, "Id", "Title", result.RoleId);
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
            ViewData["MyDate"] = _viewModel.BirthDate;
            bool result = _adminService.UpdateUser(id, _viewModel);
            if (result)
                return RedirectToPage("UserList");

            return Page();
        }
    }
}
