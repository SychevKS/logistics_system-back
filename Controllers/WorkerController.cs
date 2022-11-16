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
        private readonly ILogService _logService;
        public WorkerController(IWorkerService workerService, ILogService logService)
        {
            _workerService = workerService;
            _logService = logService;
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
            _logService.AddWrite($"Обновление сотрудника, {worker.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpPost("workers")]
        public void AddWorker([FromQuery] Worker worker)
        {
            _workerService.AddWorker(worker);
            _logService.AddWrite($"Добавление сотрудника, {worker.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpDelete("workers")]
        public void RemoveWorker(Guid workerId)
        {
            _workerService.RemoveWorker(workerId);
            _logService.AddWrite($"Удаление сотрудника, {workerId}.", HttpContext.User.Identity.Name);
        }

    }
}
