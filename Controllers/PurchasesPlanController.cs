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
    public class PurchasesPlanController : Controller
    {
        private readonly IPurchasesPlanService _purchasesPlanService;
        public PurchasesPlanController(IPurchasesPlanService purchasesPlanService)
        {
            _purchasesPlanService = purchasesPlanService;
        }

        [HttpGet("sales-plan/{id}/purchases-plans")]
        public IActionResult GetPurchasesPlans(Guid id)
        {
            return Ok(_purchasesPlanService.GetPurchasesPlans(id));
        }

        [HttpGet("purchases-plans/{id}")]
        public IActionResult GetPurchasesPlan(Guid id)
        {
            return Ok(_purchasesPlanService.GetPurchasesPlan(id));
        }

        [HttpPost("purchases-plans")]
        public void AddPurchasesPlan([FromQuery] PurchasesPlan purchasesPlan)
        {
            _purchasesPlanService.AddPurchasesPlan(purchasesPlan);
        }

    }
}
