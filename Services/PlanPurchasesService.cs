namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class PlanPurchasesService : IPlanPurchasesService
    {
        private readonly ApplicationContext _db;

        public PlanPurchasesService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PlanPurchasesDTO> GetPlans(Guid planSalesId)
        {
            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.PlanSales.Id == planSalesId)
                .Select(x => new PlanPurchasesDTO(x));
        }

        /// <inheritdoc/>
        public PlanPurchasesDTO? GetPlan(Guid id)
        {
            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.Id == id)
                .Select(x => new PlanPurchasesDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public PlanPurchases GetCurrentPlan(DateTime date)
        {
            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.PlanSales.Year == date.Year)
                .Where(x => x.Month == (tMonth)date.Month - 1)
                .First();
        }

        /// <inheritdoc/>
        public void AddPlan(PlanPurchases planPurchases)
        {
            _db.PlansPurchases.Add(planPurchases);
            _db.SaveChanges();
        }
    }

}
