namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер планов продаж
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class SalesPlanController : Controller
    {
        private readonly ISalesPlanService _salesPlanService;
        public SalesPlanController(ISalesPlanService salesPlanService)
        {
            _salesPlanService = salesPlanService;
        }

        [Route("sales-plans")]
        public IActionResult GetSalesPlans()
        {
            return Ok(_salesPlanService.GetSalesPlans());
        }

    }
}
