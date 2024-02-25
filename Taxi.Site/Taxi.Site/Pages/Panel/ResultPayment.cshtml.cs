using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Panel
{
    public class ResultPaymentModel : PageModel
    {
        private readonly IPanelService _panelService;
        public Factor factor { get; set; }
        public ResultPaymentModel(IPanelService panelService)
        {
            _panelService=panelService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            factor = await _panelService.GetFactor(id);
            return Page();
        }
    }
}
