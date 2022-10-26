namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

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

        /// <summary>
        /// Получение плана закупок по айди
        /// </summary>
        /// <returns></returns>
        PurchasesPlanDTO GetPurchasesPlan(Guid id);

        /// <summary>
        /// Получение текущего плана закупок
        /// </summary>
        /// <returns></returns>
        PurchasesPlan GetCurrentPurchasesPlan();

        /// <summary>
        /// Добавление плана закупок
        /// </summary>
        /// <param name="purchasesPlan"></param>
        void AddPurchasesPlan(PurchasesPlan purchasesPlan);
    }
}
