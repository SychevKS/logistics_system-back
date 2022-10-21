namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;

    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly ApplicationContext _db;

        public PurchaseInvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PurchaseInvoiceDTO> GetPurchaseInvoices()
        {
            return _db.PurchaseInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.Division)
                .Include(x => x.Partner)
                .Select(x => new PurchaseInvoiceDTO(x));
        }
    }

}
