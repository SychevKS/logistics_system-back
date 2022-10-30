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
        public void AddRealization(InvoicePosition invoicePosition)
        {
            SalesInvoiceDTO salesInvoice = _salesInvoiceService
                .GetSalesInvoice(invoicePosition.InvoiceId);

            SalesPlan salesPlan = _salesPlanService.GetCurrentSalesPlan();

            SalesPlanPosition? isNoPisition = _db.SalesPlanPositions
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .FirstOrDefault();

            if (isNoPisition == null)
            {
                return;
            }

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
