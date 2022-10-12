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
        public IEnumerable<SalesInvoice>? SalesInvoices { get; set; }
        public IEnumerable<PurchaseInvoice>? PurchaseInvoices { get; set; }

    }
}
