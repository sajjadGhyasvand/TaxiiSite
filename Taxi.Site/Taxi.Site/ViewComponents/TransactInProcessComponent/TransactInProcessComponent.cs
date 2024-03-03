using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Taxii.Core.Interfaces;


namespace Taxi.Site.ViewComponents.LastTransactComponent
{
    public class TransacInProcessComponent : ViewComponent
    {
        private readonly IAdminService _adminService;

        public TransacInProcessComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }
        private PersianCalendar pc = new PersianCalendar();


        public async Task<IViewComponentResult> InvokeAsync()
        {
            string strToday = pc.GetYear(DateTime.Now).ToString("0000") + "/" +
                pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");

            return await Task.FromResult((IViewComponentResult)View("ViewTransactInProcess", _adminService.FillTransactInProcess(strToday)));
        }
    }
}
