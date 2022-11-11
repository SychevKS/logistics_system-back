namespace logistics_system_back.DataTransferObjects
{
    using Abstractions;
    using Models;
    using DataTransferObjects;

    public class PlanSalesPositionDTO
    {
        private readonly IPlanSalesPositionService _planSalesPositionService;

        public PlanSalesPositionDTO(IPlanSalesPositionService planSalesPositionService)
        {
            _planSalesPositionService = planSalesPositionService;
        }

        public PlanSalesPositionDTO(PlanSalesPosition position)
        {
            Id = position.Product.Id;
            Name = position.Product.Name;
            Unit = position.Product.Unit != null
                ? new UnitDTO(position.Product.Unit) 
                : null;
            Purpose = position.Quantity;
            Realization = _planSalesPositionService
                .GetLastRealization(position.PlanSalesId, position.ProductId);
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Purpose { get; set; }
        public int? Realization { get; set; }
        public UnitDTO? Unit { get; set; }

    }
}
