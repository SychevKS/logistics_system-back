namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class SalesPlanPositionDTO
    {
        public SalesPlanPositionDTO(SalesPlanPosition salesPlanPosition)
        {
            Id = salesPlanPosition.Id;
            Quantity = salesPlanPosition.Quantity;
            SalesPlan = new SalesPlanDTO(salesPlanPosition.SalesPlan);
            Product = new ProductDTO(salesPlanPosition.Product);
        }

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public SalesPlanDTO SalesPlan { get; set; }
        public ProductDTO Product { get; set; }

    }
}
