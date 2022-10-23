namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class InvoicePositionService : IInvoicePositionService
    {
        private readonly ApplicationContext _db;
        private readonly IPurchasesPlanRealizationService _purchasesPlanRealizationService;
        private readonly ISalesPlanRealizationService _salesPlanRealizationService;
        private readonly IRemainingService _remainingService;

        public InvoicePositionService(
            ApplicationContext context, 
            IPurchasesPlanRealizationService purchasesPlanRealizationService,
            ISalesPlanRealizationService salesPlanRealizationService,
            IRemainingService remainingService
            )
        {
            _db = context;
            _purchasesPlanRealizationService = purchasesPlanRealizationService;
            _salesPlanRealizationService = salesPlanRealizationService;
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
        public void AddPurchasesPositions(InvoicePosition[] invoicePositions)
        {
            foreach(InvoicePosition invoicePosition in invoicePositions)
            {
                _remainingService.AddPurchasesRemains(invoicePosition);
                _purchasesPlanRealizationService.AddRealization(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddSalesPositions(InvoicePosition[] invoicePositions)
        {
            foreach (InvoicePosition invoicePosition in invoicePositions)
            {
                _remainingService.AddSalesRemains(invoicePosition);
                _salesPlanRealizationService.AddRealization(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddInOutPositions(InvoicePosition[] invoicePositions)
        {
            foreach (InvoicePosition invoicePosition in invoicePositions)
            {
                _remainingService.AddInOutRemains(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

    }
    
}
