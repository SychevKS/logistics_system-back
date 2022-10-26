namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class SalesPlanService : ISalesPlanService
    {
        private readonly ApplicationContext _db;

        public SalesPlanService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<SalesPlanDTO> GetSalesPlans()
        {
            return _db.SalesPlans.Select(x => new SalesPlanDTO(x));
        }

        /// <inheritdoc/>
        public SalesPlan GetSalesPlan(Guid id)
        {
            return _db.SalesPlans.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <inheritdoc/>
        public SalesPlan GetCurrentSalesPlan()
        {
            return _db.SalesPlans
                .Where(x => x.Year == DateTime.Now.Year)
                .First();
        }


        /// <inheritdoc/>
        public void AddSalesPlan(SalesPlan salesPlan)
        {
            _db.SalesPlans.Add(salesPlan);
            _db.SaveChanges();
        }
    }

}
