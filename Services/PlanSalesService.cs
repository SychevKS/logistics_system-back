namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class PlanSalesService : IPlanSalesService
    {
        private readonly ApplicationContext _db;

        public PlanSalesService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PlanSalesDTO> GetPlans()
        {
            return _db.PlansSales.Select(x => new PlanSalesDTO(x));
        }

        /// <inheritdoc/>
        public PlanSales? GetPlan(Guid id)
        {
            return _db.PlansSales.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <inheritdoc/>
        public PlanSales GetCurrentPlan(DateTime date)
        {
            return _db.PlansSales
                .Where(x => x.Year == date.Year)
                .First();
        }


        /// <inheritdoc/>
        public void AddPlan(PlanSales planSales)
        {
            _db.PlansSales.Add(planSales);
            _db.SaveChanges();
        }
    }

}
