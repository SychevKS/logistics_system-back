namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

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


    }
}
