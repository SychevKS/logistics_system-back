namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с накладными
    /// </summary>
    public interface IInvoiceService
    {

        /// <summary>
        /// Удаление накладной
        /// </summary>
        void RemoveInvoice(Guid invoiceId);

        /// <summary>
        /// Получение списка позиций накладной
        /// </summary>
        /// <returns></returns>
        IEnumerable<InvoicePositionDTO> GetInvoicePositions(Guid invoiceId);

        /// <summary>
        /// Добавление позиций накладной
        /// </summary>
        /// <returns></returns>
        void AddPositions(InvoicePosition[] positions);

        /// <summary>
        /// Получение выручки
        /// </summary>
        /// <returns></returns>
        int GetRevenue();

        /// <summary>
        /// Получение прибыли
        /// </summary>
        /// <returns></returns>
        int GetProfit();

        /// <summary>
        /// Получение затрат на доставку
        /// </summary>
        /// <returns></returns>
        int GetShippingCosts();

    }
}
