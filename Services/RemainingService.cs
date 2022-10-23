namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    
    public class RemainingService : IRemainingService
    {
        private readonly ApplicationContext _db;
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;

        public RemainingService(
            ApplicationContext context, 
            IPurchaseInvoiceService purchaseInvoiceService
            )
        {
            _db = context;
            _purchaseInvoiceService = purchaseInvoiceService;
        }

        /// <inheritdoc/>
        public void AddRemains(InvoicePosition invoicePosition)
        {
            PurchaseInvoice purchaseInvoice = _purchaseInvoiceService
                .GetPurchaseInvoice(invoicePosition.InvoiceId);

            Remaining? lastRemains = _db.Remainings
                .Where(x => x.DivisionId == purchaseInvoice.DivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains == null ? 
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + lastRemains.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = purchaseInvoice.DivisionId,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }
    }
}
