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
