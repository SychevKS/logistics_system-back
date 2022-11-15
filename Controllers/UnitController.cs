namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Контролер ед. измерения
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [Authorize]
        [HttpGet("units")]
        public IActionResult GetUnits()
        {
            return Ok(_unitService.GetUnits());
        }

        [Authorize]
        [HttpGet("units/{id}")]
        public IActionResult GetUnit(Guid id)
        {
            return Ok(_unitService.GetUnit(id));
        }

        [Authorize]
        [HttpPut("units")]
        public void UpdateUnit([FromQuery] Unit unit)
        {
            _unitService.UpdateUnit(unit);
        }

        [Authorize]
        [HttpPost("units")]
        public void AddUnit([FromQuery] Unit unit)
        {
            _unitService.AddUnit(unit);
        }

        [Authorize]
        [HttpDelete("units")]
        public void RemoveUnit(Guid unitId)
        {
            _unitService.RemoveUnit(unitId);
        }

    }
}
