namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер ед. измерения
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly ILogService _logService;
        public UnitController(IUnitService unitService, ILogService logService)
        {
            _unitService = unitService;
            _logService = logService;
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
            _logService.AddWrite($"Обновление еденицы измерения, {unit.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpPost("units")]
        public void AddUnit([FromQuery] Unit unit)
        {
            _unitService.AddUnit(unit);
            _logService.AddWrite($"Добавление еденицы измерения, {unit.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpDelete("units")]
        public void RemoveUnit(Guid unitId)
        {
            _unitService.RemoveUnit(unitId);
            _logService.AddWrite($"Удаление еденицы измерения, {unitId}.", HttpContext.User.Identity.Name);
        }

    }
}
