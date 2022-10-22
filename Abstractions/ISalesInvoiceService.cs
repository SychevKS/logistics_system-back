namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с расходными
    /// </summary>
    public interface ISalesInvoiceService
    {
        /// <summary>
        /// Получение списка расходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<SalesInvoiceDTO> GetSalesInvoices();

        /// <summary>
        /// Добавление расходной
        /// </summary>
        /// <returns></returns>
        void AddSalesInvoice(Invoice invoice, SalesInvoice salesInvoice);

    }
}
