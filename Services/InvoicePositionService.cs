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
        private readonly IRemainingService _remainingService;

        public InvoicePositionService(
            ApplicationContext context, 
            IPurchasesPlanRealizationService purchasesPlanRealizationService,
            IRemainingService remainingService
            )
        {
            _db = context;
            _purchasesPlanRealizationService = purchasesPlanRealizationService;
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
                _remainingService.AddRemains(invoicePosition);
                _purchasesPlanRealizationService.AddPurchasesPlanRealizations(invoicePosition);
                _db.InvoicePositions.Add(invoicePosition);
            }
            _db.SaveChanges();
        }

    }
    
}
