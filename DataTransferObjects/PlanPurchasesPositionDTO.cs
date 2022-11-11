namespace logistics_system_back.DataTransferObjects
{
    using Abstractions;
    using Models;

    public class PlanPurchasesPositionDTO
    {
        private readonly IPlanPurchasesPositionService _planPurchasesPositionService;

        public PlanPurchasesPositionDTO(IPlanPurchasesPositionService planPurchasesPositionService)
        {
            _planPurchasesPositionService = planPurchasesPositionService;
        }

        public PlanPurchasesPositionDTO(PlanPurchasesPosition position)
        {
            Id = position.Product.Id;
            Name = position.Product.Name;
            Unit = position.Product.Unit != null
                ? new UnitDTO(position.Product.Unit)
                : null;
            Division = position.Division != null
                ? new DivisionDTO(position.Division)
                : null;
            Purpose = position.Quantity;
            Realization = _planPurchasesPositionService
                .GetLastRealization(position.PlanPurchasesId, position.ProductId);
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Purpose { get; set; }
        public int? Realization { get; set; }
        public UnitDTO? Unit { get; set; }
        public DivisionDTO? Division { get; set; }

    }
}
