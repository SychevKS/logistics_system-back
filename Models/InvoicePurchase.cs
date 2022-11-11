namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс приходная накладная
    /// </summary>
    public class InvoicePurchase
    { 
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public Guid DivisionId { get; set; }
        public Division? Division { get; set; }
        public Guid PartnerId { get; set; }
        public Partner? Partner { get; set; }

    }
}
