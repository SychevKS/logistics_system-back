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
    public class InvoiceTransferController : Controller
    {
        private readonly ITransferInvoiceService _transferInvoiceService;
        private readonly ILogService _logService;
        public InvoiceTransferController(ITransferInvoiceService transferInvoiceService, ILogService logService)
        {
            _transferInvoiceService = transferInvoiceService;
            _logService = logService;
        }

        [Authorize]
        [HttpGet("transfer-invoices")]
        public IActionResult GetInvoiceTransfers()
        {
            return Ok(_transferInvoiceService.GetInvoiceTransfers());
        }

        [Authorize]
        [HttpGet("transfer-invoices/{id}")]
        public IActionResult GetInvoiceTransfer(Guid id)
        {
            return Ok(_transferInvoiceService.GetInvoiceTransfer(id));
        }

        [Authorize]
        [HttpPost("transfer-invoices")]
        public void AddInvoiceTransfer([FromQuery] Invoice invoice, [FromQuery] InvoiceTransfer invoiceTransfer)
        {
            _transferInvoiceService.AddInvoiceTransfer(invoice, invoiceTransfer);
            _logService.AddWrite($"Добавление приходно-расходной накладной, {invoice.Id}.", HttpContext.User.Identity.Name);
        }

    }
}
