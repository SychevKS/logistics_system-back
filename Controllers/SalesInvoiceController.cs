namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер приходных
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class SalesInvoiceController : Controller
    {
        private readonly ISalesInvoiceService _salesInvoiceController;
        public SalesInvoiceController(ISalesInvoiceService salesInvoiceController)
        {
            _salesInvoiceController = salesInvoiceController;
        }

        [Route("sales-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_salesInvoiceController.GetSalesInvoices());
        }

    }
}
