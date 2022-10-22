namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

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
    }
}
