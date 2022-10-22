namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
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
    }

}
