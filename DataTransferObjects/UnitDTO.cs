namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class UnitDTO
    {
        public UnitDTO(Unit unit)
        {
            Id = unit.Id;
            Name = unit.Name;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

    }
}
