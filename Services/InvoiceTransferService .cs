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
        public IEnumerable<InvoiceTransferDTO> GetInvoiceTransfers()
        {
            return _db.InvoiceTransfers
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.InDivision)
                .Include(x => x.OutDivision)
                .Select(x => new InvoiceTransferDTO(x));
        }

        /// <inheritdoc/>
        public InvoiceTransferDTO GetInvoiceTransfer(Guid invoiceId)
        {
            return _db.InvoiceTransfers
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(p => p.InDivision)
                .Include(p => p.OutDivision)
                .Where(x => x.InvoiceId == invoiceId)
                .Select(x => new InvoiceTransferDTO(x))
                .First();
        }

        /// <inheritdoc/>
        public void AddInvoiceTransfer(Invoice invoice, InvoiceTransfer invoiceTransfer)
        {
            _db.Invoices.Add(invoice);
            _db.InvoiceTransfers.Add(invoiceTransfer);
            _db.SaveChanges();
        }
    }

}
