namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с позициями плана закупок
    /// </summary>
    public interface IPurchasesPlanPositionService
    {
        /// <summary>
        /// Получение списка позиций плана закупок
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchasesPlanPositionDTO> GetPurchasesPlanPositions(Guid purchasesPlanId);

        /// <summary>
        /// Добавление позиций плана закупок
        /// </summary>
        /// <returns></returns>
        void AddPositions(PurchasesPlanPosition[] purchasesPlanPositions);
    }
}
