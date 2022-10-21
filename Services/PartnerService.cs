namespace logistics_system_back.Services
{
    using Abstractions;
    using Models;

    public class PartnerService : IPartnerService
    {
        private readonly ApplicationContext _db;

        public PartnerService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<Partner> GetPartners()
        {
            return _db.Partners;
        }
    }
}
