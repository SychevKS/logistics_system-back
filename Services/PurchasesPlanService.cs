namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
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

        /// <inheritdoc/>
        public PurchasesPlanDTO GetPurchasesPlan(Guid id)
        {
            return _db.PurchasesPlans
                .Include(x => x.SalesPlan)
                .Where(x => x.Id == id)
                .Select(x => new PurchasesPlanDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public PurchasesPlan GetCurrentPurchasesPlan()
        {
            return _db.PurchasesPlans
                .Include(x => x.SalesPlan)
                .Where(x => x.SalesPlan.Year == DateTime.Now.Year)
                .Where(x => x.Month == (tMonth)DateTime.Now.Month - 1)
                .First();
        }

        /// <inheritdoc/>
        public void AddPurchasesPlan(PurchasesPlan purchasesPlan)
        {
            _db.PurchasesPlans.Add(purchasesPlan);
            _db.SaveChanges();
        }
    }

}
