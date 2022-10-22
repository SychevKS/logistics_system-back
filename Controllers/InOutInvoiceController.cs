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
    public class InOutInvoiceController : Controller
    {
        private readonly IInOutInvoiceService _inOutInvoiceService;
        public InOutInvoiceController(IInOutInvoiceService inOutInvoiceService)
        {
            _inOutInvoiceService = inOutInvoiceService;
        }

        [Route("in-out-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_inOutInvoiceService.GetInOutInvoices());
        }

        [HttpPost("add-in-out-invoice")]
        public void AddInOutInvoice([FromQuery] Invoice invoice, [FromQuery] InOutInvoice inOutInvoice)
        {
            _inOutInvoiceService.AddInOutInvoice(invoice, inOutInvoice);
        }

    }
}
