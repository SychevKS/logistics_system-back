namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с партнерами
    /// </summary>
    public interface IPartnerService
    {
        /// <summary>
        /// Получение списка партнеров
        /// </summary>
        /// <returns></returns>
        IEnumerable<PartnerDTO> GetPartners();

    }
}
