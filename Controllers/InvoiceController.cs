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
        private readonly ILogService _logService;
        public InvoiceController(IInvoiceService invoiceService, ILogService logService)
        {
            _invoiceService = invoiceService;
            _logService = logService;
        }

        [Authorize]
        [HttpDelete("invoices")]
        public void RemoveInvoice(Guid invoiceId)
        {
            _invoiceService.RemoveInvoice(invoiceId);
            _logService.AddWrite($"Удаление накладной, {invoiceId}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpGet("invoice/{id}/positions")]
        public IActionResult GetInvoicePositions(Guid id)
        {
            return Ok(_invoiceService.GetInvoicePositions(id));
        }

        [Authorize]
        [HttpPost("purchases-positions")]
        public void AddPurchasesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoiceService.AddPurchasesPositions(positions);
        }

        [Authorize]
        [HttpPost("sales-positions")]
        public void AddSalesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoiceService.AddSalesPositions(positions);
        }

        [Authorize]
        [HttpPost("transfers-positions")]
        public void AddTransferPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoiceService.AddTransferPositions(positions);
        }

    }
}
