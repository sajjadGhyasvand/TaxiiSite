using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Enum;

namespace Taxi.Site.Pages.Panel
{
    public class UpdateStatusModel : PageModel
    {
        private readonly IPanelService _panelService;

        public UpdateStatusModel(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public IActionResult OnGet(Guid id)
        {
            _panelService.UpdateStatus(id, TransactStatus.Canceled);

            return RedirectToPage("/Panel/index");
        }
    }
}
