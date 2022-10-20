namespace logistics_system_back.Services
{
    using Abstractions;
    using Models;

    public class DivisionService : IDivisionService
    {
        private readonly ApplicationContext _db;

        public DivisionService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<Division> GetDivisions()
        {
            return _db.Divisions;
        }
    }
}
