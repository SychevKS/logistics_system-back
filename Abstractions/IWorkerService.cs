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
        /// Получение работника
        /// </summary>
        /// <returns></returns>
        WorkerDTO? GetWorker(Guid workerId);

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="worker"></param>
        void UpdateWorker(Worker worker);

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="worker"></param>
        void AddWorker(Worker worker);

    }
}
