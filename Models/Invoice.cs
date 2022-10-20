namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс накладная
    /// </summary>
    public class Invoice
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Number { get; set; }
        public Guid WorkerId { get; set; }
        public Worker? Worker { get; set; }
        public PurchaseInvoice? Purchase { get; set; }
        public SalesInvoice? Sales { get; set; }
        public InOutInvoice? InOut { get; set; }
        public IEnumerable<InvoicePosition>? InvoicePositions { get; set; }

    }
}
