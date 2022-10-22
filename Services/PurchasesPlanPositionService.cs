namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;

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
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.PurchasesPlan.Id == purchasesPlanId)
                .Select(x => new PurchasesPlanPositionDTO(x));
        }

    }
    
}
