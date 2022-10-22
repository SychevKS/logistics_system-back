namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

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

        [Route("sales-plan/{id}/purchases-plans")]
        public IActionResult GetPurchasesPlans(Guid id)
        {
            return Ok(_purchasesPlanService.GetPurchasesPlans(id));
        }

    }
}
