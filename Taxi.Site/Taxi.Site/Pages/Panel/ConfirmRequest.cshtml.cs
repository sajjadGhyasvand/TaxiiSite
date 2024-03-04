using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using SixLabors.ImageSharp.PixelFormats;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Panel
{
    public class ConfirmRequestModel : PageModel
    {
        private readonly IPanelService _panelService;
        public TransactViewModel _viewModel { get; set; }
        public ConfirmRequestModel(IPanelService panelService)
        {
            _panelService = panelService;
        }
        public async Task<IActionResult> OnGet(double id, string lat1, string lat2, string lng1, string lng2)
        {
            long price = _panelService.GetPriceType(id);

            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?lat=38&lon=52&units=metric&appid=049203b664c89350e710c332de05d2b2");

            var result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(result);

            WeatherViewModel viewModel = new WeatherViewModel()
            {
                Hum = Math.Round((float)obj.main.humidity),
                Temp = Math.Round((float)obj.main.temp)
            };

            double humC = Convert.ToDouble(((viewModel.Hum) - 32) * (0.555));

            float tempPercent = _panelService.GetTempPercent(viewModel.Temp);
            float humPercent = _panelService.GetHumidityPercent(humC);

            price = Convert.ToInt64(price + (price * tempPercent));
            price = Convert.ToInt64(price + (price * humPercent));

            _viewModel = new TransactViewModel()
            {
                Fee = price,
                UserId = _panelService.GetUserId(User.Identity.Name),
                StartLat = lat1,
                StartLng = lng1,
                EndLng = lng2,
                EndLat = lat2
            };

            return Page();

        }

        [HttpPost]
        public async Task<IActionResult> OnPost(TransactViewModel viewModel)
        {
            User user = _panelService.GetUser(User.Identity.Name);

            bool isCash = true;

            if (user.Wallet >= viewModel.Fee)
            {
                isCash = false;
            }

            Transact transact = new Transact()
            {
                Id = CodeGenerators.GetId(),
                Date = DateTimeGenerators.GetShamsiDate(),
                Discount = 0,
                DriverId = null,
                DriverRate = false,
                EndAddress = viewModel.EndAddress,
                EndLat = viewModel.EndLat,
                EndLng = viewModel.EndLng,
                EndTime = null,
                Fee = viewModel.Fee,
                IsCash = isCash,
                Rate = 0,
                StartAddress = viewModel.StartAddress,
                StartLat = viewModel.StartLat,
                StartLng = viewModel.StartLng,
                StartTime = null,
                Status = 0,
                Total = viewModel.Fee,
                UserId = viewModel.UserId
            };

            _panelService.AddTransactModel(transact);

            return RedirectToPage("index");
        }
    }
}
