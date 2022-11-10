namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

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

        [HttpGet("invoice/{id}/positions")]
        public IActionResult GetInvoicePositions(Guid id)
        {
            return Ok(_invoicePositionService.GetInvoicePositions(id));
        }

        [HttpPost("purchases-positions")]
        public void AddPurchasesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddPurchasesPositions(positions);
        }

        [HttpPost("sales-positions")]
        public void AddSalesPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddSalesPositions(positions);
        }

        [HttpPost("transfers-positions")]
        public void AddTransferPositions([FromQuery] InvoicePosition[] positions)
        {
            _invoicePositionService.AddTransferPositions(positions);
        }

    }
}
