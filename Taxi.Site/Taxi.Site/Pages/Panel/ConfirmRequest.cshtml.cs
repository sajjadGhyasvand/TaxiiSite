using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;

namespace Taxi.Site.Pages.Panel
{
    public class ConfirmRequestModel : PageModel
    {
        private readonly IPanelService _panelService;
        public PriceConfirmViewModel _viewModel { get; set; }
        public ConfirmRequestModel(IPanelService panelService)
        {
            _panelService = panelService;
        }
        public async Task<IActionResult> OnGet(double id)
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

            _viewModel = new PriceConfirmViewModel()
            {
                Price = price
            };

            return Page();
        }
    }
}
