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
                .ThenInclude(x => x.SalesPlanRealization)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.SalesPlan.Id == salesPlanId)
                .Select(x => new {
                    pos = x,
                    realization = (int?) x.SalesPlan.SalesPlanRealization
                    .Where(p => p.SalesPlanId == salesPlanId && p.ProductId == x.ProductId)
                    .OrderByDescending(x => x.Date).FirstOrDefault().Quantity
                })
                .Select(x => new SalesPlanPositionDTO(x.pos, x.realization));
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
