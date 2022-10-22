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
        /// Добавление подразделения
        /// </summary>
        /// <param name="division"></param>
        void AddDivision(Division division);

    }
}
