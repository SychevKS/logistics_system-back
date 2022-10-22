namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Microsoft.EntityFrameworkCore;

    public class PurchasesPlanService : IPurchasesPlanService
    {
        private readonly ApplicationContext _db;

        public PurchasesPlanService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PurchasesPlanDTO> GetPurchasesPlans(Guid SalesPlanId)
        {
            return _db.PurchasesPlans
                .Include(x => x.SalesPlan)
                .Where(x => x.SalesPlan.Id == SalesPlanId)
                .Select(x => new PurchasesPlanDTO(x));
        }
    }

}
