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
        /// Добавление ед. измерения
        /// </summary>
        /// <returns></returns>
        void AddUnit(Unit unit);

    }
}
