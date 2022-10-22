namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер позиций плана закупок
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PurchasesPlanPositionController : Controller
    {
        private readonly IPurchasesPlanPositionService _purchasesPlanPositionService;
        public PurchasesPlanPositionController(IPurchasesPlanPositionService purchasesPlanPositionService)
        {
            _purchasesPlanPositionService = purchasesPlanPositionService;
        }

        [Route("purchases-plan/{id}/positions")]
        public IActionResult GetSalesPlanPositions(Guid id)
        {
            return Ok(_purchasesPlanPositionService.GetPurchasesPlanPositions(id));
        }


    }
}
