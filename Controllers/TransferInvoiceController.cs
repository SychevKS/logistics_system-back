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

        [Route("transfer-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_transferInvoiceService.GetTransferInvoices());
        }

        [HttpPost("add-transfer-invoice")]
        public void AddInOutInvoice([FromQuery] Invoice invoice, [FromQuery] TransferInvoice inOutInvoice)
        {
            _transferInvoiceService.AddTransferInvoice(invoice, inOutInvoice);
        }

    }
}
