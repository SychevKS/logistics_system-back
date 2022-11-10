namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

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

        [HttpGet("workers")] 
        public IActionResult GetWorkers()
        {
            return Ok(_workerService.GetWorkers());
        }

        [HttpPatch("workers/{id}")] 
        public IActionResult GetWorker(Guid id)
        {
            return Ok(_workerService.GetWorker(id));
        }

        [HttpPut("workers")]
        public void UpdateWorker([FromQuery] Worker worker)
        {
            _workerService.UpdateWorker(worker);
        }

        [HttpPost("workers")]
        public void AddWorker([FromQuery] Worker worker)
        {
            _workerService.AddWorker(worker);
        } 

    }
}
