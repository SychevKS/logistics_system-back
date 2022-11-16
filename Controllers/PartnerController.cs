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
        private readonly ILogService _logService;
        public PartnerController(IPartnerService partnerService, ILogService logService)
        {
            _partnerService = partnerService;
            _logService = logService;
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
            _logService.AddWrite($"Обновление контрагента, {partner.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpPost("partners")]
        public void AddPartner([FromQuery] Partner partner)
        {
            _partnerService.AddPartner(partner);
            _logService.AddWrite($"Добавление контрагента, {partner.Id}.", HttpContext.User.Identity.Name);
        }

        [Authorize]
        [HttpDelete("partners")]
        public void RemovePartner(Guid partnerId)
        {
            _partnerService.RemovePartner(partnerId);
            _logService.AddWrite($"Удаление контрагента, {partnerId}.", HttpContext.User.Identity.Name);
        }

    }
}
