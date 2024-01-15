using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        public void OnGet()
        {
        }
        public async Task<ActionResult> OnPost(RegisterViewModel viewModel) 
        {
            if (ModelState.IsValid)
            {
                User user = await _accountService.RegisterUser(viewModel);
                if (user != null)
                {
                    return RedirectToPage("/Account/Active");
                }
            }
            return RedirectToPage("/Register");
        }
    }
}
