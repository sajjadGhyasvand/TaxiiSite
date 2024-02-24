using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taxi.Site.Pages.Main
{
    [Authorize]
    public class indexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
