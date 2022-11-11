namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс товар
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public Guid UnitId { get; set; }
        public Unit? Unit { get; set; }
        public IEnumerable<InvoicePosition>? InvoicePositions { get; set; }
        public IEnumerable<Remaining>? Remainings { get; set; }
        public IEnumerable<PlanSalesPosition>? PlanSalesPositions { get; set; }
        public IEnumerable<PlanSalesRealization>? PlanSalesRealizations { get; set; }
        public IEnumerable<PlanPurchasesPosition>? PlanPurchasesPositions { get; set; }
        public IEnumerable<PlanPurchasesRealization>? PlanPurchasesRealizations { get; set; }

    }
}
