namespace logistics_system_back.Services
{
    using Models;
    using Abstractions;

    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationContext _db;

        public InvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        public void RemoveInvoice(Guid invoiceId)
        {
            Invoice invoice = _db.Invoices.Where(x => x.Id == invoiceId).First();
            _db.Invoices.Remove(invoice);
            _db.SaveChanges();
        }
    }
}
