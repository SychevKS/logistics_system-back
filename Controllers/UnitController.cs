namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("units")]
        public IActionResult GetUnits()
        {
            return Ok(_unitService.GetUnits());
        }

        [HttpGet("units/{id}")]
        public IActionResult GetUnit(Guid id)
        {
            return Ok(_unitService.GetUnit(id));
        }

        [HttpPut("units")]
        public void UpdateUnit([FromQuery] Unit unit)
        {
            _unitService.UpdateUnit(unit);
        }

        [HttpPost("units")]
        public void AddUnit([FromQuery] Unit unit)
        {
            _unitService.AddUnit(unit);
        }

    }
}
