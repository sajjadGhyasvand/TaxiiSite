using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Taxii.Core.Interfaces;


namespace Taxi.Site.ViewComponents.TransactInProcessComponent
{
    public class TransactInProcessComponent : ViewComponent
    {
        private readonly IAdminService _admin;

        public TransactInProcessComponent(IAdminService admin)
        {
            _admin = admin;
        }

        private PersianCalendar pc = new PersianCalendar();


        public async Task<IViewComponentResult> InvokeAsync()
        {
            string strToday = pc.GetYear(DateTime.Now).ToString("0000") + "/" +
                pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");

            return await Task.FromResult((IViewComponentResult)View("TView", await _admin.FillTransactInProcess(strToday)));
        }
    }
}
