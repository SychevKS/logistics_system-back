namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PurchasesPlanPositionDTO
    {
        public PurchasesPlanPositionDTO(PurchasesPlanPosition position, int? realization)
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
            Realization = realization != null ? realization : 0;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Purpose { get; set; }
        public int? Realization { get; set; }
        public UnitDTO? Unit { get; set; }
        public DivisionDTO? Division { get; set; }

    }
}
