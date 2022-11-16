namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Контролер подразделений
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class DivisionController : Controller
    {
        private readonly IDivisionService _divisionService;
        private readonly ILogService _logService;
        public DivisionController(IDivisionService amendmentService, ILogService logService)
        {
            _divisionService = amendmentService;
            _logService = logService;
        }

        [Authorize]
        [HttpGet("divisions")]
        public IActionResult GetDivisions()
        {
            return Ok(_divisionService.GetDivisions());
        }

        [Authorize]
        [HttpGet("divisions/{id}")]
        public IActionResult GetDivision(Guid id)
        {
            return Ok(_divisionService.GetDivision(id));
        }

        [Authorize]
        [HttpPut("divisions")]
        public void UpdateDivision([FromQuery] Division division)
        {
            _divisionService.UpdateDivision(division);
            _logService.AddWrite($"Обновление подразделения, {division.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpPost("divisions")]
        public void AddDivision([FromQuery] Division division)
        {
            _divisionService.AddDivision(division);
            _logService.AddWrite($"Добавление подразделения, {division.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpDelete("divisions")]
        public void RemoveDivision(Guid divisionId)
        {
            _divisionService.RemoveDivision(divisionId);
            _logService.AddWrite($"Удаление подразделения, {divisionId}.", HttpContext.User.Identity.Name);
        }

    }
}
