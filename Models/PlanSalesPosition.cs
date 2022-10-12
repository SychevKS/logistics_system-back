namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс позиция плана продаж
    /// </summary>
    public class PlanSalesPosition
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid PlanSalesId { get; set; }
        public PlanSales? PlanSales { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
