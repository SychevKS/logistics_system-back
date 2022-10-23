namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    
    public class RemainingService : IRemainingService
    {
        private readonly ApplicationContext _db;
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        private readonly ISalesInvoiceService _salesInvoiceService;

        public RemainingService(
            ApplicationContext context, 
            IPurchaseInvoiceService purchaseInvoiceService,
            ISalesInvoiceService salesInvoiceService
            )
        {
            _db = context;
            _purchaseInvoiceService = purchaseInvoiceService;
            _salesInvoiceService = salesInvoiceService;
        }

        /// <inheritdoc/>
        public void AddPurchasesRemains(InvoicePosition invoicePosition)
        {
            PurchaseInvoice purchaseInvoice = _purchaseInvoiceService
                .GetPurchasesInvoice(invoicePosition.InvoiceId);

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

        /// <inheritdoc/>
        public void AddSalesRemains(InvoicePosition invoicePosition)
        {
            SalesInvoice salesInvoice = _salesInvoiceService
                .GetSalesInvoice(invoicePosition.InvoiceId);

            Remaining lastRemains = _db.Remainings
                .Where(x => x.DivisionId == salesInvoice.DivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .First();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains.Quantity - invoicePosition.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = salesInvoice.DivisionId,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddInOutRemains(InvoicePosition invoicePosition)
        {

        }
    }
}
