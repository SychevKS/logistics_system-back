namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class InvoicePurchaseService : IInvoicePurchaseService
    {
        private readonly ApplicationContext _db;

        public InvoicePurchaseService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<InvoicePurchaseDTO> GetInvoicePurchases()
        {
            return _db.InvoicePurchases
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.Division)
                .Include(x => x.Partner)
                .Select(x => new InvoicePurchaseDTO(x));
        }

        /// <inheritdoc/>
        public InvoicePurchaseDTO GetInvoicePurchase(Guid invoiceId)
        {
            return _db.InvoicePurchases
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(p => p.Division)
                .Include(p => p.Partner)
                .Where(x => x.InvoiceId == invoiceId)
                .Select(x => new InvoicePurchaseDTO(x))
                .First();
        }

        /// <inheritdoc/>
        public void AddInvoicePurchase(Invoice invoice, InvoicePurchase purchaseInvoice)
        {
            _db.Invoices.Add(invoice);
            _db.InvoicePurchases.Add(purchaseInvoice);
            _db.SaveChanges();
        }
    }

}
