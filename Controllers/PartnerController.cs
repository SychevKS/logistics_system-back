namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер работников
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [Route("workers")]
        public IActionResult GetPartners()
        {
            return Ok(_workerService.GetWorkers());
        }

    }
}
