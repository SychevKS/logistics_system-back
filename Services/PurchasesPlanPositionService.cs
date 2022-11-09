namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class PurchasesPlanPositionService : IPurchasesPlanPositionService
    {
        private readonly ApplicationContext _db;

        public PurchasesPlanPositionService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PurchasesPlanPositionDTO> GetPurchasesPlanPositions(Guid purchasesPlanId)
        {
            return _db.PurchasesPlanPositions
                .Include(x => x.PurchasesPlan)
                .ThenInclude(x => x.PurchasesPlanRealizations)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division)
                .Where(x => x.PurchasesPlan.Id == purchasesPlanId)
                .Select(x => new {
                    pos = x,
                    realization = (int?)x.PurchasesPlan.PurchasesPlanRealizations
                    .Where(p => p.PurchasesPlanId == purchasesPlanId && p.ProductId == x.ProductId)
                    .OrderByDescending(x => x.Date).FirstOrDefault().Quantity
                })
                .Select(x => new PurchasesPlanPositionDTO(x.pos, x.realization));
        }

        /// <inheritdoc/>
        public void AddPositions(PurchasesPlanPosition[] positions)
        {
            foreach (PurchasesPlanPosition position in positions)
            {
                _db.PurchasesPlanPositions.Add(position);
            }
            _db.SaveChanges();
        }

    }
    
}
