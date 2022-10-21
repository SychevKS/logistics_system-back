namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс товар
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public PriceList PriceList { get; set; }
        public IEnumerable<InvoicePosition>? InvoicePositions { get; set; }
        public IEnumerable<Remaining>? Remainings { get; set; }
        public IEnumerable<SalesPlanPosition>? SalesPlanPositions { get; set; }
        public IEnumerable<SalesPlanRealization>? SalesPlanRealizations { get; set; }
        public IEnumerable<PurchasesPlanPosition>? PurchasesPlanPositions { get; set; }
        public IEnumerable<PurchasesPlanRealization>? PurchasesPlanRealizations { get; set; }

    }
}
