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
        public InvoicePurchase? Purchase { get; set; }
        public InvoiceSale? Sale { get; set; }
        public InvoiceTransfer? Transfer { get; set; }
        public IEnumerable<InvoicePosition>? InvoicePositions { get; set; }

    }
}
