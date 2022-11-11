namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер позиций плана продаж
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PlanSalesPositionController : Controller
    {
        private readonly IPlanSalesPositionService _position;
        public PlanSalesPositionController(IPlanSalesPositionService position)
        {
            _position = position;
        }

        [Authorize]
        [HttpGet("sales-plans/{id}/positions")]
        public IActionResult GetSalesPlanPositions(Guid id)
        {
            return Ok(_position.GetPositions(id));
        }

        [Authorize]
        [HttpPost("sales-plans-positions")]
        public void AddPositions([FromQuery] PlanSalesPosition[] positions)
        {
            _position.AddPositions(positions);
        }

    }
}
