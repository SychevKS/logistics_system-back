namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер приходных
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class InOutInvoiceController : Controller
    {
        private readonly IInOutInvoiceService _inOutInvoiceService;
        public InOutInvoiceController(IInOutInvoiceService inOutInvoiceService)
        {
            _inOutInvoiceService = inOutInvoiceService;
        }

        [Route("in-out-invoices")]
        public IActionResult GetSalesInvoices()
        {
            return Ok(_inOutInvoiceService.GetInOutInvoices());
        }

    }
}
