using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Discount
{
    public class EditDiscountModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public DiscountAdminViewModel _viewModel { get; set; }
        public EditDiscountModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetDiscountById(guid);
            _viewModel = new DiscountAdminViewModel()
            {
                Name = result.Name,
                Code = result.Code,
                Description = result.Description,
                Expire = result.Expire,
                Percent = result.Percent,
                Price = result.Price,
                Start = result.Start
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {

            bool result = _adminService.UpdateDiscount(id, _viewModel);
            if (result)
                return RedirectToPage("DiscountList");

            return Page();
        }
    }
}
