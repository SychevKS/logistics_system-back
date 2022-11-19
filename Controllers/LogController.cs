namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;

    /// <summary>
    /// Контролер логов
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("logs")]
        public IActionResult GetProducts()
        {
            return Ok(_logService.GetLogs());
        }
    }
}
