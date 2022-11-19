namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с аудитом
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Добавление записи действия пользователя
        /// </summary>
        void AddWrite(string message, string? user);

        /// <summary>
        /// Получение записей аудита
        /// </summary>
        IEnumerable<Log> GetLogs();
    }
}
