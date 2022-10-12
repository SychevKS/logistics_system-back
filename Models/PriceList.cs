namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс прайс-лист
    /// </summary>
    public class PriceList
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public int Price { get; set; }

    }
}
