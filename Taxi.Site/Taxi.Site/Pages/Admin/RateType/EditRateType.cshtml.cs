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
        public ColorViewModel _viewModel { get; set; }
        public EditRateTypeModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetColorById(guid);
            _viewModel = new ColorViewModel()
            {
                ColorCode = result.ColorCode,
                Name = result.Name
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
             
                bool result = _adminService.UpdateColor(id,_viewModel);
                if (result)
                    return RedirectToPage("RateTypeList");

            return Page();
        }
    }
}
