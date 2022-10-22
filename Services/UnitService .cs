namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class UnitService : IUnitService
    {
        private readonly ApplicationContext _db;

        public UnitService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<UnitDTO> GetUnits()
        {
            return _db.Units.Select(u => new UnitDTO(u));
        }

        /// <inheritdoc/>
        public void AddUnit(Unit unit)
        {
            _db.Units.Add(unit);
            _db.SaveChanges();
        }
    }
}
