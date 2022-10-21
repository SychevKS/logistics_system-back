namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class SalesPlanRealizationDTO
    {
        public SalesPlanRealizationDTO(SalesPlanRealization salesPlanRealization)
        {
            Id = salesPlanRealization.Id;
            Date = salesPlanRealization.Date;
            Quantity = salesPlanRealization.Quantity;
            SalesPlan = new SalesPlanDTO(salesPlanRealization.SalesPlan);
            Product = new ProductDTO(salesPlanRealization.Product);
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public SalesPlanDTO SalesPlan { get; set; }
        public ProductDTO Product { get; set; }

    }
}
