namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с планами продаж
    /// </summary>
    public interface IPlanSalesService
    {
        /// <summary>
        /// Получение списка планов продаж
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlanSalesDTO> GetPlans();

        /// <summary>
        /// Получение плана продаж по айди
        /// </summary>
        /// <returns></returns>
        PlanSales? GetPlan(Guid id);

        /// <summary>
        /// Получение текущего плана продаж
        /// </summary>
        /// <returns></returns>
        PlanSales GetCurrentPlan(Guid invoiceId);

        /// <summary>
        /// Добавление плана продаж
        /// </summary>
        /// <param name="planSales"></param>
        void AddPlan(PlanSales planSales);

        /// <summary>
        /// Удаление плана продаж
        /// </summary>
        /// <param name="planId"></param>
        void RemovePlan(Guid planId);

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
    }
}
