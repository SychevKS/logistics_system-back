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
        IEnumerable<InvoiceTransferDTO> GetInvoiceTransfers();

        /// <summary>
        /// Получение приходно-расходной
        /// </summary>
        /// <returns></returns>
        InvoiceTransferDTO GetInvoiceTransfer(Guid invoiceId);

        /// <summary>
        /// Добавление приходно-расходной
        /// </summary>
        /// <returns></returns>
        void AddInvoiceTransfer(Invoice invoice, InvoiceTransfer transferInvoice);

    }
}
