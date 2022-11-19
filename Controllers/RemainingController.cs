namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;

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

        [Authorize]
        [HttpGet("remainings/{id}")]
        public IActionResult GetRemainings(Guid id)
        {
            return Ok(_remainingService.GetRemainings(id));
        }

        [Authorize]
        [HttpGet("remainings")]
        public IActionResult GetRemainings()
        {
            return Ok(_remainingService.GetRemainings());
        }

    }
}
