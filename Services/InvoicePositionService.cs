namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class InvoicePositionService : IInvoicePositionService
    {
        private readonly ApplicationContext _db;
        private readonly IPlanPurchasesPositionService _planPurchasesPositionService;
        private readonly IPlanSalesPositionService _planSalesPositionService;
        private readonly IRemainingService _remainingService;

        public InvoicePositionService(
            ApplicationContext context,
            IPlanPurchasesPositionService planPurchasesPositionService,
            IPlanSalesPositionService planSalesPositionService,
            IRemainingService remainingService
            )
        {
            _db = context;
            _planPurchasesPositionService = planPurchasesPositionService;
            _planSalesPositionService = planSalesPositionService;
            _remainingService = remainingService;
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
            foreach(InvoicePosition invoicePosition in positions)
            {
                _remainingService.AddPurchasesRemains(invoicePosition);
                _planPurchasesPositionService.AddRealization(invoicePosition);
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
                _planSalesPositionService.AddRealization(invoicePosition);
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
