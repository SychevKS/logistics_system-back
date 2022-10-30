namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с реализацией плана продаж
    /// </summary>
    public interface ISalesPlanRealizationService
    {
        /// <summary>
        /// Добавление записи о реализации плана продаж
        /// </summary>
        /// <returns></returns>
        void AddRealization(InvoicePosition invoicePosition);

    }
}
