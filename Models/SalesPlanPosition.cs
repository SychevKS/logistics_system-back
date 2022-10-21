namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс позиция плана продаж
    /// </summary>
    public class SalesPlanPosition
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid SalesPlanId { get; set; }
        public SalesPlan SalesPlan { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
