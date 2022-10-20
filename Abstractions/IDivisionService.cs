namespace logistics_system_back.Abstractions
{
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
        IEnumerable<Division> GetDivisions();

    }
}
