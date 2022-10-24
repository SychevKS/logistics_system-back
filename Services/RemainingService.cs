namespace logistics_system_back.Services
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using DataTransferObjects;
    
    public class RemainingService : IRemainingService
    {
        private readonly ApplicationContext _db;
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        private readonly ISalesInvoiceService _salesInvoiceService;
        private readonly ITransferInvoiceService _transferInvoiceService;

        public RemainingService(
            ApplicationContext context, 
            IPurchaseInvoiceService purchaseInvoiceService,
            ISalesInvoiceService salesInvoiceService,
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
            var a = _db.Remainings
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.DivisionId == divisionId)
                .GroupBy(x => x.ProductId)
                .Select(x => x.OrderByDescending(x => x.Date).First())
                .Select(x => new RemainingDTO(x));

            return _db.Remainings
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Where(x => x.DivisionId == divisionId)
                .GroupBy(x => x.ProductId)
                .Select(x => x.OrderByDescending(x => x.Date).First()).ToList()
                .Select(x => new RemainingDTO(x));
        }

        /// <inheritdoc/>
        public void AddPurchasesRemains(InvoicePosition invoicePosition)
        {
            PurchaseInvoice purchaseInvoice = _purchaseInvoiceService
                .GetPurchasesInvoice(invoicePosition.InvoiceId);

            Remaining? lastRemains = _db.Remainings
                .Where(x => x.DivisionId == purchaseInvoice.DivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains == null ? 
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + lastRemains.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = purchaseInvoice.DivisionId,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddSalesRemains(InvoicePosition invoicePosition)
        {
            SalesInvoice salesInvoice = _salesInvoiceService
                .GetSalesInvoice(invoicePosition.InvoiceId);

            Remaining lastRemains = _db.Remainings
                .Where(x => x.DivisionId == salesInvoice.DivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .First();

            lastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = lastRemains.Quantity - invoicePosition.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = salesInvoice.DivisionId,
            };

            _db.Remainings.Add(lastRemains);
            _db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddInOutRemains(InvoicePosition invoicePosition)
        {
            TransferInvoice inOutInvoice = _transferInvoiceService
                .GetTransferInvoice(invoicePosition.InvoiceId);

            Remaining? inLastRemains = _db.Remainings
                .Where(x => x.DivisionId == inOutInvoice.InDivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            Remaining outLastRemains = _db.Remainings
                .Where(x => x.DivisionId == inOutInvoice.OutDivisionId)
                .Where(x => x.ProductId == invoicePosition.ProductId)
                .OrderByDescending(x => x.Date)
                .First();

            inLastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = inLastRemains == null ?
                    invoicePosition.Quantity :
                    invoicePosition.Quantity + inLastRemains.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = inOutInvoice.InDivisionId,
            };

            outLastRemains = new Remaining
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Quantity = outLastRemains.Quantity - invoicePosition.Quantity,
                ProductId = invoicePosition.ProductId,
                DivisionId = inOutInvoice.OutDivisionId,
            };

            _db.Remainings.Add(inLastRemains);
            _db.Remainings.Add(outLastRemains);
            _db.SaveChanges();
        }

    }
}
