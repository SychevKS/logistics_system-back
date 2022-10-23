namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с остатками
    /// </summary>
    public interface IRemainingService
    {
        /// <summary>
        /// Добавление записи при приходе товара
        /// </summary>
        /// <returns></returns>
        void AddPurchasesRemains(InvoicePosition invoicePosition);

        /// <summary>
        /// Добавление записи при расходе товара
        /// </summary>
        /// <returns></returns>
        void AddSalesRemains(InvoicePosition invoicePosition);

        /// <summary>
        /// Добавление записи при акте приемки-передачи товара
        /// </summary>
        /// <returns></returns>
        void AddInOutRemains(InvoicePosition invoicePosition);

    }
}
