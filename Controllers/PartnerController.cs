namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("partners/{id}")]
        public IActionResult GetPartner(Guid id)
        {
            return Ok(_partnerService.GetPartner(id));
        }

        [Authorize]
        [HttpPut("partners")]
        public void UpdatePartner([FromQuery] Partner partner)
        {
            _partnerService.UpdatePartner(partner);
        }

        [Authorize]
        [HttpPost("partners")]
        public void AddPartner([FromQuery] Partner partner)
        {
            _partnerService.AddPartner(partner);
        }

        [Authorize]
        [HttpDelete("partners")]
        public void RemovePartner(Guid partnerId)
        {
            _partnerService.RemovePartner(partnerId);
        }

    }
}
