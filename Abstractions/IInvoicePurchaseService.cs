namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с приходными
    /// </summary>
    public interface IInvoicePurchaseService
    {
        /// <summary>
        /// Получение списка приходных
        /// </summary>
        /// <returns></returns>
        IEnumerable<InvoicePurchaseDTO> GetInvoicePurchases();

        /// <summary>
        /// Получение приходной
        /// </summary>
        /// <returns></returns>
        InvoicePurchaseDTO GetInvoicePurchase(Guid invoiceId);

        /// <summary>
        /// Добавление приходной
        /// </summary>
        /// <returns></returns>
        void AddInvoicePurchase(Invoice invoice, InvoicePurchase purchaseInvoice);

    }
}
