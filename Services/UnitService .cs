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
        public UnitDTO? GetUnit(Guid unitId)
        {
            return _db.Units
                .Where(x => x.Id == unitId)
                .Select(x => new UnitDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateUnit(Unit unit)
        {
            _db.Units.Update(unit);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddUnit(Unit unit)
        {
            _db.Units.Add(unit);
            _db.SaveChanges();
        }

        public void RemoveUnit(Guid unitId)
        {
            Unit unit = _db.Units.Where(x => x.Id == unitId).First();
            _db.Units.Remove(unit);
            _db.SaveChanges();
        }

    }
}
