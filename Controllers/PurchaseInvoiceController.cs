namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер приходных
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PurchaseInvoiceController : Controller
    {
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        public PurchaseInvoiceController(IPurchaseInvoiceService purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
        }

        [HttpGet("purchase-invoices")]
        public IActionResult GetPurchaseInvoices()
        {
            return Ok(_purchaseInvoiceService.GetPurchaseInvoices());
        }

        [HttpGet("purchase-invoices/{id}")]
        public IActionResult GetPurchasesInvoice(Guid id)
        {
            return Ok(_purchaseInvoiceService.GetPurchasesInvoice(id));
        }

        [HttpPost("purchase-invoices")]
        public void AddPurchaseInvoice([FromQuery] Invoice invoice, [FromQuery] PurchaseInvoice purchaseInvoice)
        {
            _purchaseInvoiceService.AddPurchaseInvoice(invoice, purchaseInvoice);
        }

    }
}
