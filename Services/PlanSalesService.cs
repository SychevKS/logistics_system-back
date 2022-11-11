namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class PlanSalesService : IPlanSalesService
    {
        private readonly ApplicationContext _db;
        private readonly IInvoiceSaleService _invoiceSaleService;

        public PlanSalesService(
            ApplicationContext context,
            IInvoiceSaleService invoiceSaleService)
        {
            _db = context;
            _invoiceSaleService = invoiceSaleService;
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
        public PlanSales GetCurrentPlan(Guid invoiceId)
        {
            DateTime date = _invoiceSaleService.GetInvoiceSale(invoiceId).Date;

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
