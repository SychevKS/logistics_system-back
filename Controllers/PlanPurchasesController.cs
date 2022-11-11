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
        private readonly IPlanPurchasesService _planPurchasesService;
        public PlanPurchasesController(IPlanPurchasesService planPurchasesService)
        {
            _planPurchasesService = planPurchasesService;
        }

        [Authorize]
        [HttpGet("sales-plan/{id}/purchases-plans")]
        public IActionResult GetPurchasesPlans(Guid id)
        {
            return Ok(_planPurchasesService.GetPlans(id));
        }

        [Authorize]
        [HttpGet("purchases-plans/{id}")]
        public IActionResult GetPurchasesPlan(Guid id)
        {
            return Ok(_planPurchasesService.GetPlan(id));
        }

        [Authorize]
        [HttpPost("purchases-plans")]
        public void AddPurchasesPlan([FromQuery] PlanPurchases purchasesPlan)
        {
            _planPurchasesService.AddPlan(purchasesPlan);
        }

    }
}
