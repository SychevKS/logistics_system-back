namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с реализацией плана закупок
    /// </summary>
    public interface IPurchasesPlanRealizationService
    {
        /// <summary>
        /// Добавление записи о реализации плана закупок
        /// </summary>
        /// <returns></returns>
        void AddRealization(InvoicePosition invoicePosition);
    }
}
