using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Entities;
using Taxii.DataLayer.Enum;

namespace Taxi.Site.Pages.Main
{
   
    public class indexModel : PageModel
    {
        private readonly IPanelService _panelService;
        public DashboardViewModel _viewModel { get; set; }
        public indexModel(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public IActionResult OnGet()
        {
            User user = _panelService.GetUser(User.Identity.Name);

            Guid? transactID = _panelService.ExistsUserTransact(user.Id);

            TransactStatus status = TransactStatus.None;
            Guid? driverID = null;

            if (transactID != null)
            {
                Transact transact = _panelService.GetUserTransact((Guid)transactID);

                status = transact.Status;
                driverID = transact.DriverId;
            }

            _viewModel = new DashboardViewModel()
            {
                DriverId = driverID,
                UserId = user.Id,
                TransactId = transactID,
                Status = status
            };

            return Page();
        }
    }
}
