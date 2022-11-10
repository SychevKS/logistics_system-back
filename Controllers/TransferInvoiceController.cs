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
    public class TransferInvoiceController : Controller
    {
        private readonly ITransferInvoiceService _transferInvoiceService;
        public TransferInvoiceController(ITransferInvoiceService transferInvoiceService)
        {
            _transferInvoiceService = transferInvoiceService;
        }

        [HttpGet("transfer-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_transferInvoiceService.GetTransferInvoices());
        }

        [HttpGet("transfer-invoices/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_transferInvoiceService.GetTransferInvoice(id));
        }

        [HttpPost("transfer-invoices")]
        public void AddInOutInvoice([FromQuery] Invoice invoice, [FromQuery] TransferInvoice inOutInvoice)
        {
            _transferInvoiceService.AddTransferInvoice(invoice, inOutInvoice);
        }

    }
}
