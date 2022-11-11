namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class PlanPurchasesPositionService : IPlanPurchasesPositionService
    {
        private readonly ApplicationContext _db;
        private readonly IPlanPurchasesService _planPurchasesService;

        public PlanPurchasesPositionService(
            ApplicationContext context, 
            IPlanPurchasesService planPurchasesService)
        {
            _db = context;
            _planPurchasesService = planPurchasesService;
        }

        /// <inheritdoc/>
        public IEnumerable<PlanPurchasesPositionDTO> GetPositions(Guid purchasesPlanId)
        {
            return _db.PlanPurchasesPositions
                .Include(x => x.PlanPurchases)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division)
                .Where(x => x.PlanPurchases.Id == purchasesPlanId)
                .Select(x => new PlanPurchasesPositionDTO(x));
        }

        /// <inheritdoc/>
        public void AddPositions(PlanPurchasesPosition[] positions)
        {
            foreach (PlanPurchasesPosition position in positions)
            {
                _db.PlanPurchasesPositions.Add(position);
            }
            _db.SaveChanges();
        }

        public void AddRealization(InvoicePosition invoicePosition)
        {
            PlanPurchases planPurchases = _planPurchasesService.GetCurrentPlan(
                invoicePosition.Invoice.Date);

            bool isNoPisition = _db.PlanPurchasesPositions
                .Any(x => x.ProductId == invoicePosition.ProductId);

            Division? division = invoicePosition.Invoice.Purchase.Division;

            if (isNoPisition)
            {
                PlanPurchasesRealization? lastRealization = _db.PlanPurchasesRealizations
                    .Where(x => x.DivisionId == division.Id)
                    .Where(x => x.ProductId == invoicePosition.ProductId)
                    .Where(x => x.PlanPurchasesId == planPurchases.Id)
                    .OrderByDescending(x => x.Date)
                    .FirstOrDefault();

                lastRealization = new PlanPurchasesRealization
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Quantity = lastRealization == null ?
                        invoicePosition.Quantity :
                        invoicePosition.Quantity + lastRealization.Quantity,
                    PlanPurchasesId = planPurchases.Id,
                    ProductId = invoicePosition.ProductId,
                    DivisionId = division.Id,
                };

                _db.PlanPurchasesRealizations.Add(lastRealization);
                _db.SaveChanges();
            }
            
        }

        public int? GetLastRealization(Guid planId, Guid productId)
        {
            return _db.PlanPurchasesRealizations
                .Where(p => p.PlanPurchasesId == planId && p.ProductId == productId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault()?.Quantity;

        }

    }
    
}
