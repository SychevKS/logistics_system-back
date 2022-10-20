namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

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

    }
}
