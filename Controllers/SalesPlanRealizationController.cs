namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;
    using Models;

    /// <summary>
    /// Контролер позиций плана продаж
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class SalesPlanRealizationController : Controller
    {
        private readonly ISalesPlanRealizationService _salesPlanRealizationService;
        public SalesPlanRealizationController(ISalesPlanRealizationService salesPlanRealizationService)
        {
            _salesPlanRealizationService = salesPlanRealizationService;
        }

    }
}
