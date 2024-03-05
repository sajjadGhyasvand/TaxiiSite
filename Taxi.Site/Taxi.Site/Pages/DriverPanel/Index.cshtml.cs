using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.DriverPanel
{
    public class IndexModel : PageModel
    {
        private readonly IPanelService _panelService;
        public DriverPanelViewModel _viewModel { get; set; }
        public IndexModel(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public IActionResult OnGet()
        {
            User user = _panelService.GetUser(User.Identity.Name);

            Transact transact = _panelService.GetDriverConfrimTransact(user.Id);

            if (transact == null)
            {
                _viewModel = new DriverPanelViewModel()
                {
                    DriverId = user.Id,
                    Status = 0,
                    Desc = "",
                    EndLat = "",
                    EndLng = "",
                    Price = 0,
                    StartLat = "",
                    StartLng = "",
                    TransactId = null,
                    UserId = null,
                    UserName = ""
                };

                return Page();
            }
            else
            {
                string username = _panelService.GetUserById(transact.UserId).UserDetail.FullName;

                _viewModel = new DriverPanelViewModel()
                {
                    DriverId = user.Id,
                    Status = transact.Status,
                    Desc = "",
                    EndLat = transact.EndLat,
                    EndLng = transact.EndLng,
                    Price = transact.Total,
                    StartLat = transact.StartLat,
                    StartLng = transact.StartLng,
                    TransactId = transact.Id,
                    UserId = transact.UserId,
                    UserName = username
                };

                return Page();
            }

        }

        public IActionResult OnGetEndRequest(Guid id)
        {
            _panelService.EndRequest(id);

            return RedirectToPage("Index");
        }
    }
}


