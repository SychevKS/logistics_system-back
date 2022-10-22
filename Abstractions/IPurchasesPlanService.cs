namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с планами закупок
    /// </summary>
    public interface IPurchasesPlanService
    {
        /// <summary>
        /// Получение списка планов закупок
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchasesPlanDTO> GetPurchasesPlans(Guid SalesPlanId);


    }
}
