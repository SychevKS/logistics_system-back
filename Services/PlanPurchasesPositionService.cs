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
        private readonly IInvoicePurchaseService _invoicePurchaseService;
        private readonly IPlanPurchasesPositionService _planPurchasesPositionService;

        public PlanPurchasesPositionService(
            ApplicationContext context, 
            IPlanPurchasesService planPurchasesService,
            IInvoicePurchaseService invoicePurchaseService)
        {
            _db = context;
            _planPurchasesService = planPurchasesService;
            _invoicePurchaseService = invoicePurchaseService;
        }

        /// <inheritdoc/>
        public IEnumerable<PlanPurchasesPositionDTO> GetPositions(Guid purchasesPlanId)
        {
            return _db.PlanPurchasesPositions
                .Include(x => x.PlanPurchases)
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division)
                .Where(x => x.PlanPurchasesId == purchasesPlanId)
                .Select(x => new 
                {
                    fields = x,
                    realization = (int?)
                        x.PlanPurchases.PlanPurchasesRealizations
                            .Where(p => p.PlanPurchasesId == x.PlanPurchasesId && p.ProductId == x.ProductId)
                            .OrderByDescending(p => p.Date)
                            .FirstOrDefault().Quantity
                })
                .Select(x => new PlanPurchasesPositionDTO(x.fields, x.realization));
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
            PlanPurchases? planPurchases = _planPurchasesService.GetCurrentPlan(
                invoicePosition.InvoiceId);

            bool isNoPisition = _db.PlanPurchasesPositions
                .Any(x => x.ProductId == invoicePosition.ProductId);

            DivisionDTO? division = _invoicePurchaseService
                .GetInvoicePurchase(invoicePosition.InvoiceId).Division;

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

    }
    
}
