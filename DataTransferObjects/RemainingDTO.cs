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
            Product = new ProductDTO(remaining.Product);
            Division = new DivisionDTO(remaining.Division);
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
        
        public DivisionDTO Division { get; set; }
    }
}
