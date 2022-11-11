namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class InvoiceSaleService : IInvoiceSaleService
    {
        private readonly ApplicationContext _db;

        public InvoiceSaleService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<InvoiceSaleDTO> GetInvoiceSales()
        {
            return _db.InvoiceSales
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.Division)
                .Include(x => x.Partner)
                .Select(x => new InvoiceSaleDTO(x));
        }

        /// <inheritdoc/>
        public InvoiceSaleDTO GetInvoiceSale(Guid invoiceId)
        {
            return _db.InvoiceSales
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(p => p.Division)
                .Include(p => p.Partner)
                .Where(x => x.InvoiceId == invoiceId)
                .Select(x => new InvoiceSaleDTO(x))
                .First();
        }

        /// <inheritdoc/>
        public void AddInvoiceSale(Invoice invoice, InvoiceSale invoiceSale)
        {
            _db.Invoices.Add(invoice);
            _db.InvoiceSales.Add(invoiceSale);
            _db.SaveChanges();
        }
    }

}
