namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс план закупок
    /// </summary>
    public class PurchasesPlan
    {
        public Guid Id { get; set; }
        public tMonth Month { get; set; }
        public Guid SalesPlanId { get; set; }
        public SalesPlan? SalesPlan { get; set; }
        public IEnumerable<PurchasesPlanPosition>? PurchasesPlanPositions { get; set; }
        public IEnumerable<PurchasesPlanRealization>? PurchasesPlanRealizations { get; set; }

    }
}
