namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с приходно-расходными
    /// </summary>
    public interface ITransferInvoiceService
    {
        /// <summary>
        /// Получение списка приходно-расходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<TransferInvoiceDTO> GetTransferInvoices();

        /// <summary>
        /// Получение приходно-расходной
        /// </summary>
        /// <returns></returns>
        TransferInvoice GetTransferInvoice(Guid invoiceId);

        /// <summary>
        /// Добавление приходно-расходной
        /// </summary>
        /// <returns></returns>
        void AddTransferInvoice(Invoice invoice, TransferInvoice transferInvoice);

    }
}
