using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;

namespace Taxi.Site.Pages.Admin.Report
{
    public class MonthlyFactorModel : PageModel
    {
        private IAdminService _adminService;
        private PersianCalendar pc = new();
        /*public IEnumerable<ChartViewModel> charts { get; set; }*/
        public List<ChartViewModel> charts { get; set; }
        public MonthlyFactorModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet()
        {
            charts = new();
            for (int i = 1; i <= 12; i++)
            {
                int myValue = 0;
                string strMonth = i.ToString("00");
                ChartViewModel chart = new ChartViewModel()
                {
                    Color = ColorGenerators.SelectColorCode(),
                    Label = MonthConvertor.FarsiMonth(i),
                    Value = _adminService.MonthlyFactor(strMonth)
                };

                charts.Add(chart);
            }

            return Page();
        }
    }
}
