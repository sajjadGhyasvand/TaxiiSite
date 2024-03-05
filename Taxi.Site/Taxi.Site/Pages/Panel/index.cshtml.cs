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

            string carCode = "";
            string carName = "";
            string carColor = "";
            string driverName = "";
            long price = 0;
            string avatar = "";
            string startLat = "";
            string endLat = "";
            string startLng = "";
            string endLng = "";

            if (transactID != null)
            {
                Transact transact = _panelService.GetUserTransact((Guid)transactID);

                status = transact.Status;
                driverID = transact.DriverId;
                price = transact.Total;
                startLat = transact.StartLat;
                startLng = transact.StartLng;
                endLat = transact.EndLat;
                endLng = transact.EndLng;

                if (transact.DriverId != null)
                {
                    Driver driver = _panelService.GetDriverById((Guid)transact.DriverId);
                    User driverDetail = _panelService.GetUserById((Guid)transact.DriverId);

                    driverName = driverDetail.UserDetail.FullName;
                    carCode = driver.CarCode;
                    carColor = driver.Color.Name;
                    carName = driver.Car.Name;
                }
            }

            _viewModel = new DashboardViewModel()
            {
                DriverId = driverID,
                UserId = user.Id,
                TransactId = transactID,
                Status = status,
                Avatar = avatar,
                CarCode = carCode,
                CarColor = carColor,
                CarName = carName,
                DriverName = driverName,
                Price = price,
                Wallet = user.Wallet,
                EndLat = endLat,
                EndLng = endLng,
                StartLat = startLat,
                StartLng = startLng
            };

            return Page();


            
        }

    }
}
