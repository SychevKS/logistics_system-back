namespace logistics_system_back.Services
{
    using Models;
    using Abstractions;
    using DataTransferObjects;
    using Microsoft.EntityFrameworkCore;

    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationContext _db;
        private readonly IPlanPurchasesService _planPurchasesService;
        private readonly IPlanSalesService _planSalesService;
        private readonly IRemainingService _remainingService;

        public InvoiceService(
            ApplicationContext context,
            IPlanPurchasesService planPurchasesService,
            IPlanSalesService planSalesService,
            IRemainingService remainingService
            )
        {
            _db = context;
            _planPurchasesService = planPurchasesService;
            _planSalesService = planSalesService;
            _remainingService = remainingService;
        }

        public void RemoveInvoice(Guid invoiceId)
        {
            Invoice invoice = _db.Invoices.Where(x => x.Id == invoiceId).First();
            _db.Invoices.Remove(invoice);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<InvoicePositionDTO> GetInvoicePositions(Guid invoiceId)
        {
            return _db.InvoicePositions
                .Include(p => p.Product)
                .ThenInclude(p => p.Unit)
                .Where(p => p.InvoiceId == invoiceId)
                .Select(p => new InvoicePositionDTO(p));
        }

        /// <inheritdoc/>
        public void AddPurchasesPositions(InvoicePosition[] positions)
        {
            foreach (InvoicePosition invoicePosition in positions)
            {
                _remainingService.AddPurchasesRemains(invoicePosition);
                _planPurchasesService.AddRealization(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddSalesPositions(InvoicePosition[] positions)
        {
            foreach (InvoicePosition invoicePosition in positions)
            {
                _remainingService.AddSalesRemains(invoicePosition);
                _planSalesService.AddRealization(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddTransferPositions(InvoicePosition[] positions)
        {
            foreach (InvoicePosition invoicePosition in positions)
            {
                _remainingService.AddInOutRemains(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }
    }
}
