namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер планов продаж
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PlanSalesController : Controller
    {
        private readonly IPlanSalesService _planService;
        public PlanSalesController(IPlanSalesService plan)
        {
            _planService = plan;
        }

        [Authorize]
        [HttpGet("sales-plans")]
        public IActionResult GetSalesPlans()
        {
            return Ok(_planService.GetPlans());
        }

        [Authorize]
        [HttpGet("sales-plans/{id}")]
        public IActionResult GetSalesPlan(Guid id)
        {
            return Ok(_planService.GetPlan(id));
        }

        [Authorize]
        [HttpPost("sales-plans")]
        public void AddSalesPlan([FromQuery] PlanSales planSales)
        {
            _planService.AddPlan(planSales);
        }

        [Authorize]
        [HttpDelete("sales-plans")]
        public void RemovePlan(Guid planId)
        {
            _planService.RemovePlan(planId);
        }

        [Authorize]
        [HttpGet("sales-plans/{id}/positions")]
        public IActionResult GetSalesPlanPositions(Guid id)
        {
            return Ok(_planService.GetPositions(id));
        }

        [Authorize]
        [HttpPost("sales-plans-positions")]
        public void AddPositions([FromQuery] PlanSalesPosition[] positions)
        {
            _planService.AddPositions(positions);
        }

    }
}
