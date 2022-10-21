namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

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

    }
}
