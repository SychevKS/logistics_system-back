namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class PlanPurchasesService : IPlanPurchasesService
    {
        private readonly ApplicationContext _db;
        private readonly IInvoicePurchaseService _invoicePurchaseService;

        public PlanPurchasesService(
            ApplicationContext context,
            IInvoicePurchaseService invoicePurchaseService)
        {
            _db = context;
            _invoicePurchaseService = invoicePurchaseService;
        }

        /// <inheritdoc/>
        public IEnumerable<PlanPurchasesDTO> GetPlans(Guid planSalesId)
        {
            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.PlanSales.Id == planSalesId)
                .Select(x => new PlanPurchasesDTO(x));
        }

        /// <inheritdoc/>
        public PlanPurchasesDTO? GetPlan(Guid id)
        {
            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.Id == id)
                .Select(x => new PlanPurchasesDTO(x))
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public PlanPurchases GetCurrentPlan(Guid invoiceId)
        {
            DateTime date = _invoicePurchaseService.GetInvoicePurchase(invoiceId).Date;

            return _db.PlansPurchases
                .Include(x => x.PlanSales)
                .Where(x => x.PlanSales.Year == date.Year)
                .Where(x => x.Month == (tMonth)date.Month - 1)
                .First();
        }

        /// <inheritdoc/>
        public void AddPlan(PlanPurchases planPurchases)
        {
            _db.PlansPurchases.Add(planPurchases);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void RemovePlan(Guid planId)
        {
            _db.PlansPurchases.Remove(_db.PlansPurchases.Where(x => x.Id == planId).First());
            _db.SaveChanges();
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
            PlanPurchases? planPurchases = GetCurrentPlan(
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
