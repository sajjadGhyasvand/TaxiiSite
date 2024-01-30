using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.RateType
{
    public class EditRateTypeModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public RateTypeViewModel _viewModel { get; set; }
        public EditRateTypeModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetRateTypeById(guid);
            _viewModel = new RateTypeViewModel()
            {
                 ViewOrder = result.ViewOrder,
                 OK = result.OK,
                Name = result.Name
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
            if (ModelState.IsValid)
            {
                bool result = _adminService.UpdateRateType(id,_viewModel);
                if (result)
                    return RedirectToPage("RateTypeList");
            }
            return Page();
        }
    }
}
