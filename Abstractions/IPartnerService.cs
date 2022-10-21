namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с партнерами
    /// </summary>
    public interface IPartnerService
    {
        /// <summary>
        /// Получение списка партнеров
        /// </summary>
        /// <returns></returns>
        IEnumerable<Partner> GetPartners();

    }
}
