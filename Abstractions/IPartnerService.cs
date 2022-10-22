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
        /// Добавление сотрудника
        /// </summary>
        /// <param name="partner"></param>
        void AddPartner(Partner partner);

    }
}
