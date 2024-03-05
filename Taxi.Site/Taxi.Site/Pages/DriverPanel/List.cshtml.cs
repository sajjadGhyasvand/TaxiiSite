using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.DriverPanel
{
    public class ListModel : PageModel
    {
        private readonly IPanelService _panelService;
        public ListModel(IPanelService panelService)
        {
            _panelService = panelService;
        }
        public JsonResult OnGet()
        {
                var result = _panelService.GetTransactsNotAccept();
                return new JsonResult(result);
        }
    }
}
