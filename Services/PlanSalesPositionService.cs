namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class PlanSalesPositionService : IPlanSalesPositionService
    {
        private readonly ApplicationContext _db;
        private readonly IPlanSalesService _planSalesService;

        public PlanSalesPositionService(
            ApplicationContext context,
            IPlanSalesService planSalesService)
        {
            _db = context;
            _planSalesService = planSalesService;
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
                .Select(x => new PlanSalesPositionDTO(x));
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
            PlanSales planSales = _planSalesService.GetCurrentPlan(
                invoicePosition.Invoice.Date);

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

        public int? GetLastRealization(Guid planId, Guid productId)
        {
            return _db.PlanSalesRealizations
                .Where(p => p.PlanSalesId == planId && p.ProductId == productId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault()?.Quantity;

        }

    }
    
}
