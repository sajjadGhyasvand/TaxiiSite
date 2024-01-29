using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Car
{
    public class EditCarModel : PageModel
    {
        private IAdminService _adminService;
        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public CarViewModel _viewModel { get; set; }
        public EditCarModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Guid guid = new Guid(id);
            var result = await _adminService.GetCarById(guid);
            _viewModel = new CarViewModel()
            {
                Name = result.Name
            };
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
             
                bool result = _adminService.UpdateCar(id,_viewModel);
                if (result)
                    return RedirectToPage("CarList");

            return Page();
        }
    }
}
