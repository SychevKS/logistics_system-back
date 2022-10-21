namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с работниками
    /// </summary>
    public interface IWorkerService
    {
        /// <summary>
        /// Получение списка работников
        /// </summary>
        /// <returns></returns>
        IEnumerable<Worker> GetWorkers();

    }
}
