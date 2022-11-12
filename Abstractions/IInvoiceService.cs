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

    }
}
