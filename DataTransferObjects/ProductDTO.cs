namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class ProductDTO
    {
        public ProductDTO(Product product)
        {
            ID = product.Id;
            Name = product.Name;
            Unit = product.Unit?.Name;
            Price = product.PriceList?.Price;
        }

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public int? Price { get; set; }
    }
}
