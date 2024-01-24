using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Account
{
    public class DriverRegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel _viewModel { get; set; }
        private readonly IAccountService _accountService;

        public DriverRegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                User user = await _accountService.RegisterDriver(_viewModel);
                if (user != null)
                    return RedirectToPage("/Account/Active");
            }
            return Page();
        }
    }
}
