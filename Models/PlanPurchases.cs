namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс план закупок
    /// </summary>
    public class PlanPurchases
    {
        public Guid Id { get; set; }
        public tMonth Month { get; set; }
        public Guid PlanSalesId { get; set; }
        public PlanSales? PlanSales { get; set; }
        public IEnumerable<PlanPurchasesPosition>? PlanPurchasesPisitions { get; set; }
        public IEnumerable<PlanPurchasesRealization>? PlanPurchasesRealizations { get; set; }

    }
}
