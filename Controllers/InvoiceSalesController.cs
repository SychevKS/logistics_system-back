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
    public class InvoiceSalesController : Controller
    {
        private readonly IInvoiceSaleService _salesInvoiceController;
        private readonly ILogService _logService;
        public InvoiceSalesController(IInvoiceSaleService salesInvoiceController, ILogService logService)
        {
            _salesInvoiceController = salesInvoiceController;
            _logService = logService;
        }

        [Authorize]
        [HttpGet("sale-invoices")]
        public IActionResult GetInvoiceSales()
        {
            return Ok(_salesInvoiceController.GetInvoiceSales());
        }

        [Authorize]
        [HttpGet("sale-invoices/{id}")]
        public IActionResult GetInvoiceSale(Guid id)
        {
            return Ok(_salesInvoiceController.GetInvoiceSale(id));
        }

        [Authorize]
        [HttpPost("sale-invoices")]
        public void AddInvoiceSale([FromQuery] Invoice invoice, [FromQuery] InvoiceSale salesInvoice)
        {
            _salesInvoiceController.AddInvoiceSale(invoice, salesInvoice);
            _logService.AddWrite($"Добавление расходной накладной, {invoice.Id}.", HttpContext.User.Identity.Name);
        }

    }
}
