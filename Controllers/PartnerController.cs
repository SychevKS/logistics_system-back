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

        [HttpGet("partners")]
        public IActionResult GetPartners()
        {
            return Ok(_partnerService.GetPartners());
        }

        [HttpGet("partners/{id}")]
        public IActionResult GetPartner(Guid id)
        {
            return Ok(_partnerService.GetPartner(id));
        }

        [HttpPut("partners")]
        public void UpdatePartner([FromQuery] Partner partner)
        {
            _partnerService.UpdatePartner(partner);
        }

        [HttpPost("partners")]
        public void AddPartner([FromQuery] Partner partner)
        {
            _partnerService.AddPartner(partner);
        }

    }
}
