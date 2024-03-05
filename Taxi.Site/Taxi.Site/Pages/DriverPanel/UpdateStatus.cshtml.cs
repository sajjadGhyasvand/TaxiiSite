using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;
using Taxii.DataLayer.Enum;

namespace Taxi.Site.Pages.DriverPanel
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
            User user = _panelService.GetUser(User.Identity.Name);

            _panelService.UpdateDrtiverStatus(id, user.Id, TransactStatus.UpdateDriver);

            return RedirectToAction("Index");
        }

    }
}
