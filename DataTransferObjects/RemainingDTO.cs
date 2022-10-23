namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class RemainingDTO
    {
        public RemainingDTO(Remaining remaining)
        {
            Id = remaining.Id;
            Date = remaining.Date;
            Quantity = remaining.Quantity;
            ProductId = remaining.ProductId;
            Product = new ProductDTO(remaining.Product);
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }
        
    }
}
