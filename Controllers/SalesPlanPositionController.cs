namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер позиций плана продаж
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class SalesPlanPositionController : Controller
    {
        private readonly ISalesPlanPositionService _salesPlanPositionService;
        public SalesPlanPositionController(ISalesPlanPositionService salesPlanPositionService)
        {
            _salesPlanPositionService = salesPlanPositionService;
        }

        [Route("sales-plan/{id}/positions")]
        public IActionResult GetSalesPlanPositions(Guid id)
        {
            return Ok(_salesPlanPositionService.GetSalesPlanPositions(id));
        }


    }
}
