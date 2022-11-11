namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using DataTransferObjects;
    
    public class RemainingService : IRemainingService
    {
        private readonly ApplicationContext _db;
        private readonly IInvoicePurchaseService _purchaseInvoiceService;
        private readonly IInvoiceSaleService _salesInvoiceService;
        private readonly ITransferInvoiceService _transferInvoiceService;

        public RemainingService(
            ApplicationContext context, 
            IInvoicePurchaseService purchaseInvoiceService,
            IInvoiceSaleService salesInvoiceService,
            ITransferInvoiceService transferInvoiceService
            )
        {
            _db = context;
            _purchaseInvoiceService = purchaseInvoiceService;
            _salesInvoiceService = salesInvoiceService;
            _transferInvoiceService = transferInvoiceService;
        }

        /// <inheritdoc/>
        public IEnumerable<RemainingDTO> GetRemainings(Guid divisionId)
        {
            return _db.Remainings
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division)
                .Where(x => x.DivisionId == divisionId)
                .GroupBy(x => x.ProductId)
                .Select(x => x.OrderByDescending(x => x.Date).First()).ToList()
                .Select(x => new RemainingDTO(x));
        }

        public IEnumerable<Object> GetRemainings()
        {
            return _db.Remainings
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Division).ToList()
                .GroupBy(x => x.Division)
                .Select(x => new
                {
                    division = new DivisionDTO(x.Key),
                    remainings = x.ToList()
                    .GroupBy(x => x.ProductId)
                    .Select(x => x.OrderByDescending(x => x.Date).First()).ToList()
                    .Select(x => new RemainingDTO(x))
                }).ToList();
        }

        /// <inheritdoc/>
        public void AddPurchasesRemains(InvoicePosition position)
        {
            InvoicePurchaseDTO invoice = _purchaseInvoiceService
                .GetInvoicePurchase(position.InvoiceId);

            Remaining? lastRemains = _db.Remainings
                .Where(x => x.DivisionId == invoice.Division.Id)
                .Where(x => x.ProductId == position.ProductId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains == null ?
                    position.Quantity :
                    position.Quantity + lastRemains.Quantity,
                ProductId = position.ProductId,
                DivisionId = invoice.Division.Id,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddSalesRemains(InvoicePosition position)
        {
            InvoiceSaleDTO invoice = _salesInvoiceService
                .GetInvoiceSale(position.InvoiceId);

            Remaining lastRemains = _db.Remainings
                .Where(x => x.DivisionId == invoice.Division.Id)
                .Where(x => x.ProductId == position.ProductId)
                .OrderByDescending(x => x.Date)
                .First();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains.Quantity - position.Quantity,
                ProductId = position.ProductId,
                DivisionId = invoice.Division.Id,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddInOutRemains(InvoicePosition position)
        {
            InvoiceTransferDTO invoice = _transferInvoiceService
                .GetInvoiceTransfer(position.InvoiceId);

            Remaining? inLastRemains = _db.Remainings
                .Where(x => x.DivisionId == invoice.InDivision.Id)
                .Where(x => x.ProductId == position.ProductId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            Remaining outLastRemains = _db.Remainings
                .Where(x => x.DivisionId == invoice.OutDivision.Id)
                .Where(x => x.ProductId == position.ProductId)
                .OrderByDescending(x => x.Date)
                .First();

            inLastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = inLastRemains == null ?
                    position.Quantity :
                    position.Quantity + inLastRemains.Quantity,
                ProductId = position.ProductId,
                DivisionId = invoice.InDivision.Id,
            };

            outLastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = outLastRemains.Quantity - position.Quantity,
                ProductId = position.ProductId,
                DivisionId = invoice.OutDivision.Id,
            };

            _db.Remainings.Add(inLastRemains);
            _db.Remainings.Add(outLastRemains);
            _db.SaveChanges();
        }

    }
}
