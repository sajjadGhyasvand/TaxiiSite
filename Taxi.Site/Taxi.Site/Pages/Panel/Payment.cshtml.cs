using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.Core.VireModels.Panel.Payment;
using Taxii.DataLayer.Entities;

namespace Taxi.Site.Pages.Panel
{
    public class PaymentModel : PageModel
    {
        private readonly IPanelService _panelService;

        public PaymentModel(IPanelService panelService)
        {
            _panelService=panelService;
        }
        [BindProperty]
        public FactorViewModel _viewModel { get; set; }
        public IActionResult OnGet()
        {

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            UserDetail user = await _panelService.GetUserDetail(User.Identity.Name);
            string orderNumber = CodeGenerators.GetOrderCode();

            var checkFactor = _panelService.UpdateFactor(user.UserId, orderNumber, _viewModel.Wallet);

            if (checkFactor == false)
            {
                Factor factor = new Factor()
                {
                    BankName = null,
                    Date = null,
                    Desc = null,
                    Id = CodeGenerators.GetId(),
                    OrderNumber = orderNumber,
                    Price = Convert.ToInt32(_viewModel.Wallet),
                    RefNumber = null,
                    Time = null,
                    TraceNumber = null,
                    UserId = user.UserId
                };

                _panelService.AddFactor(factor);
            }       
            Guid factorID = _panelService.GetFactorById(orderNumber);

            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(_viewModel.Wallet));
            var result = payment.PaymentRequest("تراکنش جدید", "https://localhost:7296/Panel/PaymentCallBack/" + factorID);

            if (result.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            }
            return Redirect("/Panel/ResultPayment/" + factorID);
        }
    }
}
