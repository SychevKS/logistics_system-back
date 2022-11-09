namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса пользователей
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <returns></returns>
        User? GetUser(string login, string password);

    }
}
