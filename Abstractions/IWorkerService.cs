namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
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
        IEnumerable<WorkerDTO> GetWorkers();

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="worker"></param>
        void AddWorker(Worker worker);

    }
}
