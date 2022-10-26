namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с еденицами измерения товара
    /// </summary>
    public interface IUnitService
    {
        /// <summary>
        /// Получение списка ед. измерения
        /// </summary>
        /// <returns></returns>
        IEnumerable<UnitDTO> GetUnits();

        /// <summary>
        /// Получение ед. измерения
        /// </summary>
        /// <returns></returns>
        UnitDTO? GetUnit(Guid unitId);

        /// <summary>
        /// Обновление ед. измерения
        /// </summary>
        /// <param name="unit"></param>
        void UpdateUnit(Unit unit);

        /// <summary>
        /// Добавление ед. измерения
        /// </summary>
        /// <returns></returns>
        void AddUnit(Unit unit);

    }
}
