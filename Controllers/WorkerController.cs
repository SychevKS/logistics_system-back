namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;
    using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet("workers")] 
        public IActionResult GetWorkers()
        {
            return Ok(_workerService.GetWorkers());
        }

        [Authorize]
        [HttpGet("workers/{id}")] 
        public IActionResult GetWorker(Guid id)
        {
            return Ok(_workerService.GetWorker(id));
        }

        [Authorize]
        [HttpPut("workers")]
        public void UpdateWorker([FromQuery] Worker worker)
        {
            _workerService.UpdateWorker(worker);
        }

        [Authorize]
        [HttpPost("workers")]
        public void AddWorker([FromQuery] Worker worker)
        {
            _workerService.AddWorker(worker);
        }

        [Authorize]
        [HttpDelete("workers")]
        public void RemoveWorker(Guid workerId)
        {
            _workerService.RemoveWorker(workerId);
        }

    }
}
