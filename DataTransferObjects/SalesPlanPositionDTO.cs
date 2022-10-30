namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class SalesPlanPositionDTO
    {
        public SalesPlanPositionDTO(SalesPlanPosition salesPlanPosition, int? realization)
        {
            Id = salesPlanPosition.Product.Id;
            Name = salesPlanPosition.Product.Name;
            Unit = salesPlanPosition.Product.Unit != null
                ? new UnitDTO(salesPlanPosition.Product.Unit) 
                : null;
            Purpose = salesPlanPosition.Quantity;
            Realization = realization != null ? realization : 0;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Purpose { get; set; }
        public int? Realization { get; set; }
        public UnitDTO? Unit { get; set; }

    }
}
