namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
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
        IEnumerable<PartnerDTO> GetPartners();

        /// <summary>
        /// Получение партнера
        /// </summary>
        /// <returns></returns>
        PartnerDTO? GetPartner(Guid partnerId);

        /// <summary>
        /// Обновление партнера
        /// </summary>
        /// <param name="partner"></param>
        void UpdatePartner(Partner partner);

        /// <summary>
        /// Добавление партнера
        /// </summary>
        /// <param name="partner"></param>
        void AddPartner(Partner partner);

    }
}
