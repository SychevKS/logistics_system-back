namespace logistics_system_back.Services
{
    using Abstractions;
    using DataTransferObjects;

    public class PartnerService : IPartnerService
    {
        private readonly ApplicationContext _db;

        public PartnerService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<PartnerDTO> GetPartners()
        {
            return _db.Partners.Select(p => new PartnerDTO(p));
        }
    }
}
