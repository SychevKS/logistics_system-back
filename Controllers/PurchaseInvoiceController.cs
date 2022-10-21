namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

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

        [Route("purchase-invoices")]
        public IActionResult GetPurchaseInvoices()
        {
            return Ok(_purchaseInvoiceService.GetPurchaseInvoices());
        }

    }
}
