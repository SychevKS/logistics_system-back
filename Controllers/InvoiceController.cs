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
        [HttpPost("invoice/positions")]
        public void AddPurchasesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoiceService.AddPositions(positions);
        }

        [Authorize]
        [HttpGet("statistics")]
        public IActionResult GetStatistics()
        {
            int revenue = _invoiceService.GetRevenue();
            int shippingCosts = _invoiceService.GetShippingCosts();
            int profit = _invoiceService.GetProfit();

            return Ok(new { revenue, shippingCosts, profit });
        }

    }
}
