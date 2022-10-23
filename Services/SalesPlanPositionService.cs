namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class SalesPlanPositionService : ISalesPlanPositionService
    {
        private readonly ApplicationContext _db;

        public SalesPlanPositionService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<SalesPlanPositionDTO> GetSalesPlanPositions(Guid salesPlanId)
        {
            return _db.SalesPlanPositions
                .Include(x => x.SalesPlan)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.SalesPlan.Id == salesPlanId)
                .Select(x => new SalesPlanPositionDTO(x));
        }

        /// <inheritdoc/>
        public void AddPositions(SalesPlanPosition[] salesPlanPositions)
        {
            foreach (SalesPlanPosition position in salesPlanPositions)
            {
                _db.SalesPlanPositions.Add(position);
            }
            _db.SaveChanges();
        }

    }
    
}
