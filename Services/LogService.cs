namespace logistics_system_back.Services
{
    using Abstractions;
    using Models;

    public class LogService : ILogService
    {
        private readonly ApplicationContext _db;

        public LogService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public void AddWrite(string message, string? user)
        {
            Log log = new()
            { 
                Id = Guid.NewGuid(), 
                Date = DateTime.Now, 
                Message = message, 
                UserName = user 
            };

            _db.Logs.Add(log);
            _db.SaveChanges();
        }
    }
}
