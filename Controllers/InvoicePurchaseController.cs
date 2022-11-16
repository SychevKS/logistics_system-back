namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер приходных
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class InvoicePurchaseController : Controller
    {
        private readonly IInvoicePurchaseService _purchaseInvoiceService;
        private readonly ILogService _logService;
        public InvoicePurchaseController(IInvoicePurchaseService purchaseInvoiceService, ILogService logService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
            _logService = logService;
        }

        [Authorize]
        [HttpGet("purchase-invoices")]
        public IActionResult GetInvoicePurchases()
        {
            return Ok(_purchaseInvoiceService.GetInvoicePurchases());
        }

        [Authorize]
        [HttpGet("purchase-invoices/{id}")]
        public IActionResult GetInvoicePurchase(Guid id)
        {
            return Ok(_purchaseInvoiceService.GetInvoicePurchase(id));
        }

        [Authorize]
        [HttpPost("purchase-invoices")]
        public void AddInvoicePurchase([FromQuery] Invoice invoice, [FromQuery] InvoicePurchase purchaseInvoice)
        {
            _purchaseInvoiceService.AddInvoicePurchase(invoice, purchaseInvoice);
            _logService.AddWrite($"Добавление приходной накладной, {invoice.Id}.", HttpContext.User.Identity.Name);
        }

    }
}
