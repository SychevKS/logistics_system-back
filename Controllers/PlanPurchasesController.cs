namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("sales-plan/{id}/purchases-plans")]
        public IActionResult GetPurchasesPlans(Guid id)
        {
            return Ok(_planPurchasesService.GetPlans(id));
        }

        [HttpGet("purchases-plans/{id}")]
        public IActionResult GetPurchasesPlan(Guid id)
        {
            return Ok(_planPurchasesService.GetPlan(id));
        }

        [HttpPost("purchases-plans")]
        public void AddPurchasesPlan([FromQuery] PlanPurchases purchasesPlan)
        {
            _planPurchasesService.AddPlan(purchasesPlan);
        }

    }
}
