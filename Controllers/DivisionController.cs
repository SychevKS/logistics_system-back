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
        public DivisionController(IDivisionService amendmentService)
        {
            _divisionService = amendmentService;
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
        }

        [Authorize]
        [HttpPost("divisions")]
        public void AddDivision([FromQuery] Division division)
        {
            _divisionService.AddDivision(division);
        }

    }
}
