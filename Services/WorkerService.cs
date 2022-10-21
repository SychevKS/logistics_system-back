namespace logistics_system_back.Services
{
    using Abstractions;
    using Models;

    public class WorkerService : IWorkerService
    {
        private readonly ApplicationContext _db;

        public WorkerService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<Worker> GetWorkers()
        {
            return _db.Workers;
        }
    }
}
