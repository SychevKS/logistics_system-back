namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class TransferInvoiceService : ITransferInvoiceService
    {
        private readonly ApplicationContext _db;

        public TransferInvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<TransferInvoiceDTO> GetTransferInvoices()
        {
            return _db.InOutInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.InDivision)
                .Include(x => x.OutDivision)
                .Select(x => new TransferInvoiceDTO(x));
        }

        /// <inheritdoc/>
        public TransferInvoice GetTransferInvoice(Guid invoiceId)
        {
            return _db.InOutInvoices
                .Where(x => x.InvoiceId == invoiceId)
                .First();
        }

        /// <inheritdoc/>
        public void AddTransferInvoice(Invoice invoice, TransferInvoice inOutInvoice)
        {
            _db.Invoices.Add(invoice);
            _db.InOutInvoices.Add(inOutInvoice);
            _db.SaveChanges();
        }
    }

}
