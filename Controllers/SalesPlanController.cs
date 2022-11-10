namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

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

        [HttpGet("sales-plans")]
        public IActionResult GetSalesPlans()
        {
            return Ok(_salesPlanService.GetSalesPlans());
        }

        [HttpGet("sales-plans/{id}")]
        public IActionResult GetSalesPlan(Guid id)
        {
            return Ok(_salesPlanService.GetSalesPlan(id));
        }

        [HttpPost("sales-plans")]
        public void AddSalesPlan([FromQuery] SalesPlan salesPlan)
        {
            _salesPlanService.AddSalesPlan(salesPlan);
        }

    }
}
