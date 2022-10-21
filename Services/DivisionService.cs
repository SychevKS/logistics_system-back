namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;

    public class DivisionService : IDivisionService
    {
        private readonly ApplicationContext _db;

        public DivisionService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<DivisionDTO> GetDivisions()
        {
            return _db.Divisions.Select(x => new DivisionDTO(x));
        }
    }
}
