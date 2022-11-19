namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс позиция накладной
    /// </summary>
    public class InvoicePosition
    {
        public Guid Id { get; set; } 
        public int Price { get; set; }
        public int Quantity { get; set; } 
        public int CostDelivery { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public tInvoiceKind InvoiceKind { get; set; }

    }
}
