using Microsoft.AspNetCore.Mvc;
using Taxii.Core.Interfaces;

namespace Taxi.Site.ViewComponents.LastTransactComponent
{
    public class LastTransactComponent : ViewComponent
    {
        private readonly IAdminService _adminService;

        public LastTransactComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ViewLastTransact", _adminService.LastTransact()));
        }
    }
}
