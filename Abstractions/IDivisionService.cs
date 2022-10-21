namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

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

    }
}
