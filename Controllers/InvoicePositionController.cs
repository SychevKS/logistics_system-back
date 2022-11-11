namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Контролер позиций наклодной
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class InvoicePositionController : Controller
    {
        private readonly IInvoicePositionService _invoicePositionService;
        public InvoicePositionController(IInvoicePositionService invoicePositionService)
        {
            _invoicePositionService = invoicePositionService;
        }

        [Authorize]
        [HttpGet("invoice/{id}/positions")]
        public IActionResult GetInvoicePositions(Guid id)
        {
            return Ok(_invoicePositionService.GetInvoicePositions(id));
        }

        [Authorize]
        [HttpPost("purchases-positions")]
        public void AddPurchasesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddPurchasesPositions(positions);
        }

        [Authorize]
        [HttpPost("sales-positions")]
        public void AddSalesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddSalesPositions(positions);
        }

        [Authorize]
        [HttpPost("transfers-positions")]
        public void AddTransferPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddTransferPositions(positions);
        }

    }
}
