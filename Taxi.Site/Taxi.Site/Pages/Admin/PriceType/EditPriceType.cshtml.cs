using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.PriceType
{
    public class EditPriceTypeModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public PriceTypeViewModel _viewModel { get; set; }
        public EditPriceTypeModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetPriceTypeById(guid);
            _viewModel = new PriceTypeViewModel()
            {
                Name = result.Name,
                Start = result.Start,
                End = result.End,
                Price = result.Price,
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {

            bool result = _adminService.UpdatePriceType(id, _viewModel);
            if (result)
                return RedirectToPage("PriceTypeList");

            return Page();
        }
    }
}
