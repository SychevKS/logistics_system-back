namespace logistics_system_back.Abstractions
{
    using Models;
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с остатками
    /// </summary>
    public interface IRemainingService
    {
        /// <summary>
        /// Получение остатка на подразделении
        /// </summary>
        /// <returns></returns>
        IEnumerable<RemainingDTO> GetRemainings(Guid divisionId);

        /// <summary>
        /// Получение остатка на подразделениях
        /// </summary>
        /// <returns></returns>
        IEnumerable<Object> GetRemainings();

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
