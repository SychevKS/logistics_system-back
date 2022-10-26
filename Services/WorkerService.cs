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
        public WorkerDTO? GetWorker(Guid workerId)
        {
            return _db.Workers
                .Where(x => x.Id == workerId)
                .Select(x => new WorkerDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public void AddWorker(Worker worker)
        {
            _db.Workers.Add(worker);
            _db.SaveChanges();
        }

        public void UpdateWorker(Worker worker)
        {
            _db.Workers.Update(worker);
            _db.SaveChanges();
        }
    }
}
