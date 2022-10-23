namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly ApplicationContext _db;

        public PurchaseInvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PurchaseInvoiceDTO> GetPurchaseInvoices()
        {
            return _db.PurchaseInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.Division)
                .Include(x => x.Partner)
                .Select(x => new PurchaseInvoiceDTO(x));
        }

        /// <inheritdoc/>
        public PurchaseInvoice GetPurchaseInvoice(Guid invoiceId)
        {
            return _db.PurchaseInvoices
                .Where(x => x.InvoiceId == invoiceId)
                .First();
        }

        /// <inheritdoc/>
        public void AddPurchaseInvoice(Invoice invoice, PurchaseInvoice purchaseInvoice)
        {
            _db.Invoices.Add(invoice);
            _db.PurchaseInvoices.Add(purchaseInvoice);
            _db.SaveChanges();
        }
    }

}
