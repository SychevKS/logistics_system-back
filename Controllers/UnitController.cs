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

        [Route("units")]
        public IActionResult GetUnits()
        {
            return Ok(_unitService.GetUnits());
        }

        
        [HttpPost("add-unit")]
        public void AddUnit([FromQuery] Unit unit)
        {
            _unitService.AddUnit(unit);
        }

    }
}
