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

        [Route("invoice/{id}/positions")]
        public IActionResult GetInvoicePositions(Guid id)
        {
            return Ok(_invoicePositionService.GetInvoicePositions(id));
        }

        [HttpPost("add-purchases-positions")]
        public void AddPurchasesPositions([FromQuery] InvoicePosition[] invoicePositions)
        {
            _invoicePositionService.AddPurchasesPositions(invoicePositions);
        }

    }
}
