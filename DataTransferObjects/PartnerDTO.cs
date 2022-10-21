namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PartnerDTO
    {
        public PartnerDTO(Partner partner)
        {
            Id = partner.Id;
            Name = partner.Name;
            Kind = partner.Kind;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public tPartnerKind? Kind { get; set; }

    }
}
