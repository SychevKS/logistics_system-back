namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class ProductDTO
    {
        public ProductDTO(Product product)
        {
            ID = product.Id;
            Name = product.Name;
            Price = product.Price;
            Unit = new UnitDTO(product.Unit);
        }

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public UnitDTO Unit { get; set; }
        public int? Price { get; set; }
    }
}
