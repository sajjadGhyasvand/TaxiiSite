using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taxi.Site.Pages.Panel
{
    public class RateModel : PageModel
    {
        private readonly IPanelService _panelService;
        public DashboardViewModel _viewModel { get; set; }
        public RateModel(IPanelService panelService)
        {
            _panelService = panelService;
        }
        public IActionResult OnGet(Guid id, int rate)
        {
            _panelService.UpdateRate(id, rate);

            return RedirectToPage("index");
        }

    }
}
