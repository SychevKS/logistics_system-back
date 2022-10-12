namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс еденица измерения товара
    /// </summary>
    public class Unit
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
