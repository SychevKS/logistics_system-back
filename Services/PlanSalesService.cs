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

        /// <inheritdoc/>
        public IEnumerable<PlanSalesPositionDTO> GetPositions(Guid salesPlanId)
        {
            return _db.PlanSalesPositions
                .Include(x => x.PlanSales)
                .ThenInclude(x => x.PlanSalesRealizations)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.PlanSales.Id == salesPlanId)
                .Select(x => new
                {
                    fields = x,
                    realization = (int?)
                        x.PlanSales.PlanSalesRealizations
                            .Where(p => p.PlanSalesId == x.PlanSalesId && p.ProductId == x.ProductId)
                            .OrderByDescending(p => p.Date)
                            .FirstOrDefault().Quantity
                })
                .Select(x => new PlanSalesPositionDTO(x.fields, x.realization));
        }

        /// <inheritdoc/>
        public void AddPositions(PlanSalesPosition[] salesPlanPositions)
        {
            foreach (PlanSalesPosition position in salesPlanPositions)
            {
                _db.PlanSalesPositions.Add(position);
            }
            _db.SaveChanges();
        }

        public void AddRealization(InvoicePosition invoicePosition)
        {
            PlanSales? planSales = GetCurrentPlan(
                invoicePosition.InvoiceId);

            bool isNoPisition = _db.PlanSalesPositions
                .Any(x => x.ProductId == invoicePosition.ProductId);

            if (isNoPisition)
            {
                PlanSalesRealization? lastRealization = _db.PlanSalesRealizations
                    .Where(x => x.ProductId == invoicePosition.ProductId)
                    .Where(x => x.PlanSalesId == planSales.Id)
                    .OrderByDescending(x => x.Date)
                    .FirstOrDefault();

                lastRealization = new PlanSalesRealization
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Quantity = lastRealization == null ?
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + lastRealization.Quantity,
                    ProductId = invoicePosition.ProductId,
                    PlanSalesId = planSales.Id,
                };

                _db.PlanSalesRealizations.Add(lastRealization);
                _db.SaveChanges();
            }

        }
    }

}
