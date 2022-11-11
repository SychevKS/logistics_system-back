namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с позициями плана закупок
    /// </summary>
    public interface IPlanPurchasesPositionService
    {
        /// <summary>
        /// Получение списка позиций плана закупок
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlanPurchasesPositionDTO> GetPositions(Guid purchasesPlanId);

        /// <summary>
        /// Добавление позиций плана закупок
        /// </summary>
        /// <returns></returns>
        void AddPositions(PlanPurchasesPosition[] purchasesPlanPositions);

        /// <summary>
        /// Добавление позиции реализации плана закупок
        /// </summary>
        /// <returns></returns>
        void AddRealization(InvoicePosition invoicePosition);

        /// <summary>
        /// Получение последней реализации товара по плану
        /// </summary>
        /// <returns></returns>
        int? GetLastRealization(Guid planId, Guid productId);

    }
}
