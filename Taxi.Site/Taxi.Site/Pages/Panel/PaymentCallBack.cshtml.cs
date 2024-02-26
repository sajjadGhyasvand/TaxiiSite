using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Panel
{
    public class PaymentCallBackModel : PageModel
    {
        private readonly IPanelService _panelService;

        public PaymentCallBackModel(IPanelService panelService)
        {
            _panelService=panelService;
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            Factor factor = await _panelService.GetFactor(id);
            string authority = HttpContext.Request.Query["Authority"];

            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(factor.Price));
            var result = payment.Verification(authority).Result;
            if (result.Status == 100)
            {
                _panelService.UpdatePayment(id, DateTimeGenerators.GetShamsiDate(), DateTimeGenerators.GetShamsiTime(), "افزایش اعتبار زرین پال", "زرین پال", result.RefId.ToString(), result.RefId.ToString());
            }

            return Redirect("/Panel/ResultPayment/" + id);
        }
    }
}
