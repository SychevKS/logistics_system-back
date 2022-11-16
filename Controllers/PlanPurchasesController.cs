namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер планов закупок
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PlanPurchasesController : Controller
    {
        private readonly IPlanPurchasesService _planService;
        private readonly ILogService _logService;
        public PlanPurchasesController(IPlanPurchasesService planPurchasesService, ILogService logService)
        {
            _planService = planPurchasesService;
            _logService = logService;
        }

        [Authorize]
        [HttpGet("sales-plan/{id}/purchases-plans")]
        public IActionResult GetPurchasesPlans(Guid id)
        {
            return Ok(_planService.GetPlans(id));
        }

        [Authorize]
        [HttpGet("purchases-plans/{id}")]
        public IActionResult GetPurchasesPlan(Guid id)
        {
            return Ok(_planService.GetPlan(id));
        }

        [Authorize]
        [HttpPost("purchases-plans")]
        public void AddPurchasesPlan([FromQuery] PlanPurchases purchasesPlan)
        {
            _planService.AddPlan(purchasesPlan);
            _logService.AddWrite($"Добавление плана закупок, {purchasesPlan.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpDelete("purchases-plans")]
        public void RemovePlan(Guid planId)
        {
            _planService.RemovePlan(planId);
            _logService.AddWrite($"Удаление плана закупок, {planId}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpGet("purchases-plans/{id}/positions")]
        public IActionResult GetPositions(Guid id)
        {
            return Ok(_planService.GetPositions(id));
        }

        [Authorize]
        [HttpPost("purchases-plan-positions")]
        public void AddPositions([FromQuery] PlanPurchasesPosition[] positions)
        {
            _planService.AddPositions(positions);
        }
    }
}
