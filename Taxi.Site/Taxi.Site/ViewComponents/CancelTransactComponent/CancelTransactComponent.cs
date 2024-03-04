using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Taxii.Core.Interfaces;

namespace Snapp.Site.ViewComponents.LastTransactComponent
{
    public class CancelTransactComponent : ViewComponent
    {
        private readonly IAdminService _adminService;

        public CancelTransactComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }

        private PersianCalendar pc = new PersianCalendar();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string strToday = pc.GetYear(DateTime.Now).ToString("0000") + "/" +
                pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");

            return await Task.FromResult((IViewComponentResult)View("ViewCancelTransact",await _adminService.FillCancelTransact(strToday)));
        }
    }
}
