using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Account
{
    

    public class ActiveModel : PageModel
    {
        private readonly IAccountService _accountService;
        [BindProperty]
        public ActiveViewModel _viewModel { get; set; }
        public ActiveModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
            ViewData["IsError"] = false;
        }
        public async Task<IActionResult> OnPost( )
        {
            User user = await _accountService.ActiveUser(_viewModel);

            if (user != null)
            {
              // Ê—Êœ  
            }
            

            return RedirectToPage("/");
        }
    }
}
