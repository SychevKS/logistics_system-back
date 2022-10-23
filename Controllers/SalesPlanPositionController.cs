namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

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

        [HttpPost("add-sales-plan-positions")]
        public void AddPositions([FromQuery] SalesPlanPosition[] salesPlanPositions)
        {
            _salesPlanPositionService.AddPositions(salesPlanPositions);
        }

    }
}
