namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

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

        [Route("divisions")]
        public IActionResult GetDivisions()
        {
            return Ok(_divisionService.GetDivisions());
        }

        [Route("division/{id}")]
        public IActionResult GetDivision(Guid id)
        {
            return Ok(_divisionService.GetDivision(id));
        }

        [HttpPost("update-division")]
        public void UpdateDivision([FromQuery] Division division)
        {
            _divisionService.UpdateDivision(division);
        }

        [HttpPost("add-division")]
        public void AddDivision([FromQuery] Division division)
        {
            _divisionService.AddDivision(division);
        }

    }
}
