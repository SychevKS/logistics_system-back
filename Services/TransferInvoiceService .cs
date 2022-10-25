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
            return _db.TransferInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.InDivision)
                .Include(x => x.OutDivision)
                .Select(x => new TransferInvoiceDTO(x));
        }

        /// <inheritdoc/>
        public TransferInvoiceDTO GetTransferInvoice(Guid invoiceId)
        {
            return _db.TransferInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(p => p.InDivision)
                .Include(p => p.OutDivision)
                .Where(x => x.InvoiceId == invoiceId)
                .Select(x => new TransferInvoiceDTO(x))
                .First();
        }

        /// <inheritdoc/>
        public void AddTransferInvoice(Invoice invoice, TransferInvoice inOutInvoice)
        {
            _db.Invoices.Add(invoice);
            _db.TransferInvoices.Add(inOutInvoice);
            _db.SaveChanges();
        }
    }

}
