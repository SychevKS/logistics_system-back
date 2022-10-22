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

        [Route("sales-plans")]
        public IActionResult GetSalesPlans()
        {
            return Ok(_salesPlanService.GetSalesPlans());
        }

        [HttpPost("add-sales-plan")]
        public void AddUnit([FromQuery] SalesPlan salesPlan)
        {
            _salesPlanService.AddSelesPlan(salesPlan);
        }

    }
}
