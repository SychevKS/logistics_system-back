namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с планами продаж
    /// </summary>
    public interface ISalesPlanService
    {
        /// <summary>
        /// Получение списка планов продаж
        /// </summary>
        /// <returns></returns>
        IEnumerable<SalesPlanDTO> GetSalesPlans();

        /// <summary>
        /// Добавление плана продаж
        /// </summary>
        /// <param name="salesPlan"></param>
        void AddSelesPlan(SalesPlan salesPlan);
    }
}
