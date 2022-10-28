namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с позициями накладных
    /// </summary>
    public interface IInvoicePositionService
    {
        /// <summary>
        /// Получение списка позиций накладной
        /// </summary>
        /// <returns></returns>
        IEnumerable<InvoicePositionDTO> GetInvoicePositions(Guid invoiceId);

        /// <summary>
        /// Добавление позиций приходной накладной
        /// </summary>
        /// <returns></returns>
        void AddPurchasesPositions(InvoicePosition[] positions);

        /// <summary>
        /// Добавление позиций расходной накладной
        /// </summary>
        /// <returns></returns>
        void AddSalesPositions(InvoicePosition[] positions);

        /// <summary>
        /// Добавление позиций акта приемки-передачи
        /// </summary>
        /// <returns></returns>
        void AddTransferPositions(InvoicePosition[] positions);

    }
}
