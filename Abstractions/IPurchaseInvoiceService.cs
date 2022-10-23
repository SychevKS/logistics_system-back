namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

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

        /// <summary>
        /// Получение приходной
        /// </summary>
        /// <returns></returns>
        PurchaseInvoice GetPurchasesInvoice(Guid invoiceId);

        /// <summary>
        /// Добавление приходной
        /// </summary>
        /// <returns></returns>
        void AddPurchaseInvoice(Invoice invoice, PurchaseInvoice purchaseInvoice);

    }
}
