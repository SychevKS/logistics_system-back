namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;

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

    }
    
}
