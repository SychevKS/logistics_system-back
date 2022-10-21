namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс остатки товара
    /// </summary>
    public class Remaining
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DivisionId { get; set; }
        public Division Division { get; set; }

    }
}
