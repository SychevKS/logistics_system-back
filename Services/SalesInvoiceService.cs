namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly ApplicationContext _db;

        public SalesInvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<SalesInvoiceDTO> GetSalesInvoices()
        {
            return _db.SalesInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.Division)
                .Include(x => x.Partner)
                .Select(x => new SalesInvoiceDTO(x));
        }

        /// <inheritdoc/>
        public void AddSalesInvoice(Invoice invoice, SalesInvoice salesInvoice)
        {
            _db.Invoices.Add(invoice);
            _db.SalesInvoices.Add(salesInvoice);
            _db.SaveChanges();
        }
    }

}
