namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using DataTransferObjects;
    
    public class SalesPlanRealizationService : ISalesPlanRealizationService
    {
        private readonly ApplicationContext _db;
        private readonly ISalesInvoiceService _salesInvoiceService;
        private readonly ISalesPlanService _salesPlanService;

        public SalesPlanRealizationService(
            ApplicationContext context,
            ISalesInvoiceService purchaseInvoiceService,
            ISalesPlanService purchasesPlanService
            )
        {
            _db = context;
            _salesInvoiceService = purchaseInvoiceService;
            _salesPlanService = purchasesPlanService;
        }

        /// <inheritdoc/>
        public IEnumerable<Object> GetRealizations(Guid salesPlanId)
        {
            return _db.SalesPlanRealizations
                .Include(x => x.SalesPlan)
                .ThenInclude(x => x.SalesPlanPosition)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.SalesPlan.Id == salesPlanId)
                .GroupBy(x => x.ProductId)
                .Select(x => x.OrderByDescending(x => x.Date).First()).ToList()
                .Select(x => new
                {
                    id = x.Id,
                    Product = new ProductDTO(x.Product),
                    Realization = x.Quantity,
                    Purpose = x.SalesPlan.SalesPlanPosition
                        .Where(p => p.ProductId == x.ProductId && p.SalesPlanId == salesPlanId)
                        .FirstOrDefault()
                        ?.Quantity
                });
        }

        /// <inheritdoc/>
        public void AddRealization(InvoicePosition invoicePosition)
        {
            SalesInvoiceDTO salesInvoice = _salesInvoiceService
                .GetSalesInvoice(invoicePosition.InvoiceId);

            SalesPlan salesPlan = _salesPlanService.GetCurrentSalesPlan();

            SalesPlanRealization? lastRealization = _db.SalesPlanRealizations
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .Where(x => x.SalesPlanId == salesPlan.Id)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            lastRealization = new SalesPlanRealization
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRealization == null ?
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + lastRealization.Quantity,
                ProductId = invoicePosition.ProductId,
                SalesPlanId = salesPlan.Id,
            };
            
            _db.SalesPlanRealizations.Add(lastRealization);
            _db.SaveChanges();
        }
    }
}
