namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;

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

        /// <inheritdoc/>
        public DivisionDTO? GetDivision(Guid divisionId)
        {
            return _db.Divisions
                .Where(x => x.Id == divisionId)
                .Select(x => new DivisionDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateDivision(Division division)
        {
            _db.Divisions.Update(division);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddDivision(Division division)
        {
            _db.Divisions.Add(division);
            _db.SaveChanges();
        }

        public void RemoveDivision(Guid divisionId)
        {
            Division division = _db.Divisions.First(x => x.Id == divisionId);
            _db.Divisions.Remove(division);
            _db.SaveChanges();
        }

    }
}
