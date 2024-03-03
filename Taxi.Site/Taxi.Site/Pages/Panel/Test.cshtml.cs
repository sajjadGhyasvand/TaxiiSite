using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Taxii.Core.VireModels.Panel;

namespace Taxi.Site.Pages.Panel
{
    public class TestModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?lat=58&lon=38&appid=049203b664c89350e710c332de05d2b2");

            var result = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<dynamic>(result);

            WeatherViewModel viewModel = new WeatherViewModel()
            {
                Temp = Math.Round(((float)obj.main.temp * 9 / 5 - 459.67), 2),
                Hum = Math.Round((float)obj.main.humidity, 2)
            };

            return Content(result);
        }
    }
}
