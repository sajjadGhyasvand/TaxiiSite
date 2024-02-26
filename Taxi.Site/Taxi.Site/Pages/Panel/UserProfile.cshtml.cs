using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.Core.VireModels.Panel;

namespace Taxi.Site.Pages.Panel
{
    public class UserProfileModel : PageModel
    {
        private readonly IPanelService _panelService;

        public UserProfileModel(IPanelService panelService)
        {
            _panelService=panelService;
        }
        [BindProperty]
        public UserDetailProfileViewModel _viewModel { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var result = await _panelService.GetUserDetail(User.Identity.Name);
             _viewModel = new UserDetailProfileViewModel()
            {
                BirthDate  = result.BirthDate,
                FullName = result.FullName
            };
            ViewData["IsSuccess"] = "false";
            ViewData["MyDate"] = DateTimeGenerators.GetShamsiDate();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _panelService.GetUserDetail(User.Identity.Name);
            ViewData["MyDate"] = _viewModel.BirthDate;
            bool updateRes = _panelService.UpdateUserDetailsProfile(result.UserId, _viewModel);
            if (updateRes)
                ViewData["IsSuccess"] = "true";
            return Page();
        }
    }
}
