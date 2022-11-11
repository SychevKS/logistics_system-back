namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс контрагент
    /// </summary>
    public class Partner
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public tPartnerKind? Kind { get; set; }
        public IEnumerable<InvoiceSale>? InvoiceSales { get; set; }
        public IEnumerable<InvoicePurchase>? InvoicePurchases { get; set; }

    }
}
