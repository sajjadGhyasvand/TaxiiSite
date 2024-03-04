using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.DriverPanel
{
    public class IndexModel : PageModel
    {
        private readonly IPanelService _panelService;
        public List<Transact> TransactLsit { get; set; }
        public IndexModel(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public IActionResult OnGet()
        {
            TransactLsit = _panelService.GetTransactsNotAccept();

            return Page();
        }
    }
}
