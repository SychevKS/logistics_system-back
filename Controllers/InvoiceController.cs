namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер накладных
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [Authorize]
        [HttpDelete("invoices")]
        public void AddInvoicePurchase(Guid invoiceId)
        {
            _invoiceService.RemoveInvoice(invoiceId);
        }

    }
}
