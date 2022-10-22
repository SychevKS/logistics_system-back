namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с позициями плана продаж
    /// </summary>
    public interface ISalesPlanPositionService
    {
        /// <summary>
        /// Получение списка позиций плана продаж
        /// </summary>
        /// <returns></returns>
        IEnumerable<SalesPlanPositionDTO> GetSalesPlanPositions(Guid salesPlanId);
    }
}
