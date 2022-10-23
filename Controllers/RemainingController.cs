﻿namespace logistics_system_back.Controllers
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

        [Route("remainings/{id}")]
        public IActionResult GetRemainings(Guid id)
        {
            return Ok(_remainingService.GetRemainings(id));
        }

    }
}
