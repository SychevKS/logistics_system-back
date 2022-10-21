namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с приходными
    /// </summary>
    public interface IPurchaseInvoiceService
    {
        /// <summary>
        /// Получение списка приходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseInvoiceDTO> GetPurchaseInvoices();

    }
}
