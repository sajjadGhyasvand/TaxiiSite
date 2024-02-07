using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;

namespace Taxi.Site.Pages.Admin.Car
{
    public class ImportFileModel : PageModel
    {
        private IAdminService _adminService;
        public ImportFileModel(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(IFormFile file)
        {
            if (file != null)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int i = 2; i <= rowCount; i++)
                        {
                            CarViewModel viewModel = new CarViewModel()
                            {
                                Name = worksheet.Cells[i, 1].Value.ToString().Trim(),
                            };
                            _adminService.AddCar(viewModel);
                        }
                    }
                }
                return RedirectToPage("CarList");
            }
            else
            {
                ModelState.AddModelError("Name", "فایلی انتخاب نشده است");

                return Page();
            }
        }
    }
}
