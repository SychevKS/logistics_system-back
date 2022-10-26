namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер контрагентов
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [Route("partners")]
        public IActionResult GetPartners()
        {
            return Ok(_partnerService.GetPartners());
        }

        [Route("partner/{id}")]
        public IActionResult GetPartner(Guid id)
        {
            return Ok(_partnerService.GetPartner(id));
        }

        [HttpPost("update-partner")]
        public void UpdatePartner([FromQuery] Partner partner)
        {
            _partnerService.UpdatePartner(partner);
        }

        [HttpPost("add-partner")]
        public void AddPartner([FromQuery] Partner partner)
        {
            _partnerService.AddPartner(partner);
        }

    }
}
