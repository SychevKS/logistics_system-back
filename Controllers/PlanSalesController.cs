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
    public class PlanSalesController : Controller
    {
        private readonly IPlanSalesService _plan;
        public PlanSalesController(IPlanSalesService plan)
        {
            _plan = plan;
        }

        [HttpGet("sales-plans")]
        public IActionResult GetSalesPlans()
        {
            return Ok(_plan.GetPlans());
        }

        [HttpGet("sales-plans/{id}")]
        public IActionResult GetSalesPlan(Guid id)
        {
            return Ok(_plan.GetPlan(id));
        }

        [HttpPost("sales-plans")]
        public void AddSalesPlan([FromQuery] PlanSales planSales)
        {
            _plan.AddPlan(planSales);
        }

    }
}
