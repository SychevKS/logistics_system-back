namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс позиция плана закупок
    /// </summary>
    public class PlanPurchasesPosition
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid PlanPurchasesId { get; set; }
        public PlanPurchases? PlanPurchases { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid DivisionId { get; set; }
        public Division? Division { get; set; }

    }
}
