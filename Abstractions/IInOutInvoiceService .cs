namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с приходно-расходными
    /// </summary>
    public interface IInOutInvoiceService
    {
        /// <summary>
        /// Получение списка приходно-расходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutInvoiceDTO> GetInOutInvoices();

        /// <summary>
        /// Получение приходно-расходной
        /// </summary>
        /// <returns></returns>
        InOutInvoice GetInOutInvoice(Guid invoiceId);

        /// <summary>
        /// Добавление приходно-расходной
        /// </summary>
        /// <returns></returns>
        void AddInOutInvoice(Invoice invoice, InOutInvoice inOutInvoice);

    }
}
