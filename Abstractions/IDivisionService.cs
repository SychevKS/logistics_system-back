namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с подразделениями
    /// </summary>
    public interface IDivisionService
    {
        /// <summary>
        /// Получение списка подразделений
        /// </summary>
        /// <returns></returns>
        IEnumerable<DivisionDTO> GetDivisions();

        /// <summary>
        /// Получение подразделения
        /// </summary>
        /// <returns></returns>
        DivisionDTO? GetDivision(Guid divisionId);

        /// <summary>
        /// Обновление подразделения
        /// </summary>
        /// <param name="division"></param>
        void UpdateDivision(Division division);

        /// <summary>
        /// Добавление подразделения
        /// </summary>
        /// <param name="division"></param>
        void AddDivision(Division division);

    }
}
