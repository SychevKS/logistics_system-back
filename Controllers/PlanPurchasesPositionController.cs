namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер позиций плана закупок
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PlanPurchasesPositionController : Controller
    {
        private readonly IPlanPurchasesPositionService _position;
        public PlanPurchasesPositionController(IPlanPurchasesPositionService position)
        {
            _position = position;
        }

        [HttpGet("purchases-plan/{id}/positions")]
        public IActionResult GetSalesPlanPositions(Guid id)
        {
            return Ok(_position.GetPositions(id));
        }

        [HttpPost("purchases-plan-positions")]
        public void AddPositions([FromQuery] PlanPurchasesPosition[] positions)
        {
            _position.AddPositions(positions);
        }

    }
}
