using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.User
{
    public class DriverCarModel : PageModel
    {
        private readonly IAdminService _adminService;
        [BindProperty]
        public DriverCarViewModel _viewModel { get; set; }
        public SelectList Cars;
        public SelectList Colors;
        public DriverCarModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            var driver = await _adminService.GetDriver(id);
            var carList = await _adminService.GetCars();
            var colorList = await _adminService.GetColors();
            _viewModel = new DriverCarViewModel()
            {
                CarCode = driver.CarCode,
                CarId = driver.CarId,
                ColorId = driver.ColorId,
            };
            if (driver.CarId == null)
                 Cars = new SelectList(carList, "Id", "Name");
            else
                Cars = new SelectList(carList, "Id", "Name", _viewModel.CarId);
            if (driver.ColorId == null)
                Colors = new SelectList(colorList, "Id", "Name");
            else
                Colors = new SelectList(colorList, "Id", "Name", _viewModel.ColorId);


            ViewData["IsSuccess"] = "false";

            return Page();
        }
        public async Task<IActionResult> OnPost(Guid id)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = _adminService.UpdateDriverCar(id, _viewModel);
            }
            if (result)
            {
                ViewData["IsSuccess"] = "true";
            }
            else
            {
                ViewData["IsSuccess"] = "false";
            }
            var carList = await _adminService.GetCars();
            var colorList = await _adminService.GetColors();
            Cars = new SelectList(carList, "Id", "Name", _viewModel.CarId);
            Colors = new SelectList(colorList, "Id", "Name", _viewModel.ColorId);
            return Page();
        }
    }
}
