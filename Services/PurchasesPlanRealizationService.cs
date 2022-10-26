namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using DataTransferObjects;
    
    public class PurchasesPlanRealizationService : IPurchasesPlanRealizationService
    {
        private readonly ApplicationContext _db;
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        private readonly IPurchasesPlanService _purchasesPlanService;

        public PurchasesPlanRealizationService(
            ApplicationContext context,
            IPurchaseInvoiceService purchaseInvoiceService,
            IPurchasesPlanService purchasesPlanService
            )
        {
            _db = context;
            _purchaseInvoiceService = purchaseInvoiceService;
            _purchasesPlanService = purchasesPlanService;
        }

        /// <inheritdoc/>
        public IEnumerable<Object> GetRealizations(Guid purchasePlanId)
        {
            return _db.PurchasesPlanRealizations
                .Include(x => x.PurchasesPlan)
                .ThenInclude(x => x.PurchasesPlanPositions)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division)
                .Where(x => x.PurchasesPlan.Id == purchasePlanId)
                .GroupBy(x => new { x.ProductId, x.DivisionId })
                .Select(x => x.OrderByDescending(x => x.Date).First()).ToList()
                .Select(x => new
                {
                    id = x.Id,
                    Product = new ProductDTO(x.Product),
                    Division = new DivisionDTO(x.Division),
                    Realization = x.Quantity,
                    Purpose = x.PurchasesPlan.PurchasesPlanPositions
                        .Where(p => p.ProductId == x.ProductId && p.PurchasesPlanId == purchasePlanId)
                        .FirstOrDefault()
                        ?.Quantity
                });
        }

        /// <inheritdoc/>
        public void AddRealization(InvoicePosition invoicePosition)
        {
            PurchaseInvoiceDTO purchaseInvoice = _purchaseInvoiceService
                .GetPurchasesInvoice(invoicePosition.InvoiceId);

            PurchasesPlan purchasesPlan = _purchasesPlanService.GetCurrentPurchasesPlan();

            PurchasesPlanRealization? lastRealization = _db.PurchasesPlanRealizations
                .Where(x => x.DivisionId == purchaseInvoice.Division.Id)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .Where(x => x.PurchasesPlanId == purchasesPlan.Id)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            lastRealization = new PurchasesPlanRealization
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRealization == null ?
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + lastRealization.Quantity,
                PurchasesPlanId = purchasesPlan.Id,
                ProductId = invoicePosition.ProductId,
                DivisionId = purchaseInvoice.Division.Id,
            };
            
            _db.PurchasesPlanRealizations.Add(lastRealization);
            _db.SaveChanges();
        }
    }
}
