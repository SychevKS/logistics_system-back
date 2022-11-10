namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер остатков
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class RemainingController : Controller
    {
        private readonly IRemainingService _remainingService;
        public RemainingController(IRemainingService remainingService)
        {
            _remainingService = remainingService;
        }

        [HttpGet("remainings/{id}")]
        public IActionResult GetRemainings(Guid id)
        {
            return Ok(_remainingService.GetRemainings(id));
        }

        [HttpGet("remainings")]
        public IActionResult GetRemainings()
        {
            return Ok(_remainingService.GetRemainings());
        }

    }
}
