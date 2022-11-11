namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с расходными
    /// </summary>
    public interface IInvoiceSaleService
    {
        /// <summary>
        /// Получение списка расходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<InvoiceSaleDTO> GetInvoiceSales();

        /// <summary>
        /// Получение расходной
        /// </summary>
        /// <returns></returns>
        InvoiceSaleDTO GetInvoiceSale(Guid invoiceId);

        /// <summary>
        /// Добавление расходной
        /// </summary>
        /// <returns></returns>
        void AddInvoiceSale(Invoice invoice, InvoiceSale salesInvoice);

    }
}
