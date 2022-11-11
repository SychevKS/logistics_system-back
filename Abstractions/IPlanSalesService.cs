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
        PlanSales GetCurrentPlan(DateTime date);

        /// <summary>
        /// Добавление плана продаж
        /// </summary>
        /// <param name="planSales"></param>
        void AddPlan(PlanSales planSales);
    }
}
