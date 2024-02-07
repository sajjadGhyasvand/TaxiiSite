using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Humidity
{
    public class EditMonthPriceType : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public PriceMonthViewModel _viewModel { get; set; }
        public EditMonthPriceType(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetHumidityById(guid);
            _viewModel = new PriceMonthViewModel()
            {
                Name = result.Name,
                Start = result.Start,
                End = result.End,
                Percent = result.Percent,
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {

            bool result = _adminService.UpdateHumidity(id, _viewModel);
            if (result)
                return RedirectToPage("MonthPriceTypeList");

            return Page();
        }
    }
}
