namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с позициями плана продаж
    /// </summary>
    public interface IPlanSalesPositionService
    {
        /// <summary>
        /// Получение списка позиций плана продаж
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlanSalesPositionDTO> GetPositions(Guid salesPlanId);

        /// <summary>
        /// Добавление позиций плана продаж
        /// </summary>
        /// <returns></returns>
        void AddPositions(PlanSalesPosition[] salesPlanPositions);

        /// <summary>
        /// Добавление позиции реализации плана продаж
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
