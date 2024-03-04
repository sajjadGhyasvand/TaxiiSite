using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
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
            ViewData["IsError"] = "false";
        }
        public async Task<IActionResult> OnPost( )
        {


         


            User user = await _accountService.ActiveUser(_viewModel);

            if (user != null)
            {
            ViewData["IsError"] = "false";

                //احراز هویت ورود به داشبورد 
                var claims = new List<Claim>()
                {
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
  
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(principal, properties);
                // شناسایی  و راهنمایی به پنل 
                return RedirectToPage("/DriverPanel/Index");
            }

            ViewData["IsError"] = "true";
            return Page();
        }
    }
}
