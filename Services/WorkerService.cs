namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class WorkerService : IWorkerService
    {
        private readonly ApplicationContext _db;

        public WorkerService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<WorkerDTO> GetWorkers()
        {
            return _db.Workers.Select(p => new WorkerDTO(p));
        }

        /// <inheritdoc/>
        public void AddWorker(Worker worker)
        {
            _db.Workers.Add(worker);
            _db.SaveChanges();
        }
    }
}
