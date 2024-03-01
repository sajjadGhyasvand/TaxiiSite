using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels;

namespace Taxi.Site.Pages.Admin.Report
{
    public class WeeklyRegisterModel : PageModel
    {
        private IAdminService _adminService;
        private PersianCalendar pc = new();
        /*public IEnumerable<ChartViewModel> charts { get; set; }*/
        public List<ChartViewModel> charts { get; set; }
        public WeeklyRegisterModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet()
        {
            charts = new();
            string strToday = DateTimeGenerators.GetShamsiDate();
            int Ayear = Convert.ToInt32(strToday.Substring(0, 4));
            int Amonth = Convert.ToInt32(strToday.Substring(5, 2));
            int Aday = Convert.ToInt32(strToday.Substring(8, 2));

            string strEndDAte = "";
            int intM = 0;
            for (int i = 0; i <= 6; i++)
            {
                DateTime dtA = pc.ToDateTime(Ayear, Amonth, Aday, 0, 0, 0, 0);
                if (i == 0)
                {
                    dtA = dtA.AddDays(i);
                }
                else
                {
                    intM = -i;
                    dtA = dtA.AddDays(intM);
                }
                strEndDAte = pc.GetYear(dtA).ToString("0000") + "/" + pc.GetMonth(dtA).ToString("00") + "/" + pc.GetDayOfMonth(dtA).ToString("00");

                ChartViewModel chart = new ChartViewModel()
                {
                    Label = strEndDAte,
                    Value = _adminService.WeeklyRegister(strEndDAte),
                    Color = ColorGenerators.SelectColorCode(),
                };
                charts.Add(chart);
            }
            return Page();
        }
    }
}
