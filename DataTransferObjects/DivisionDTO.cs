namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class DivisionDTO
    {
        public DivisionDTO(Division division)
        {
            Id = division.Id;
            Number = division.Number;
            Kind = division.Kind;

        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public tDivisionKind Kind { get; set; }
    }
}
