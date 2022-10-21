namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

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

    }
}
