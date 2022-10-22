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
            Unit = product.Unit.Name;
        }

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public int? Price { get; set; }
    }
}
