namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

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

    }
}
