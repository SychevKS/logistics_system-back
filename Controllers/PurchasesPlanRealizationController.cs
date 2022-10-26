namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер позиций реализации плана закупок
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class PurchasesPlanRealizationController : Controller
    {
        private readonly IPurchasesPlanRealizationService _purchasesPlanRealizationService;
        public PurchasesPlanRealizationController(IPurchasesPlanRealizationService purchasesPlanRealizationService)
        {
            _purchasesPlanRealizationService = purchasesPlanRealizationService;
        }

        [Route("purchases-plan/{id}/realizations")]
        public IActionResult GetRealizations(Guid id)
        {
            return Ok(_purchasesPlanRealizationService.GetRealizations(id));
        }

    }
}
