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
    public class SalesInvoiceController : Controller
    {
        private readonly ISalesInvoiceService _salesInvoiceController;
        public SalesInvoiceController(ISalesInvoiceService salesInvoiceController)
        {
            _salesInvoiceController = salesInvoiceController;
        }

        [HttpGet("sales-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_salesInvoiceController.GetSalesInvoices());
        }

        [HttpGet("sales-invoices/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_salesInvoiceController.GetSalesInvoice(id));
        }

        [HttpPost("sales-invoices")]
        public void AddSalesInvoice([FromQuery] Invoice invoice, [FromQuery] SalesInvoice salesInvoice)
        {
            _salesInvoiceController.AddSalesInvoice(invoice, salesInvoice);
        }

    }
}
