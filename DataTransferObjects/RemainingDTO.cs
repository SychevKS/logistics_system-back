namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class RemainingDTO
    {
        public RemainingDTO(Remaining remaining)
        {
            Id = remaining.ProductId;
            Name = remaining.Product.Name;
            Remains = remaining.Quantity;
            Price = remaining.Product.Price;
            Unit = remaining.Product.Unit != null ? new UnitDTO(remaining.Product.Unit): null;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Remains { get; set; }
        public UnitDTO? Unit { get; set; }
        
    }
}
