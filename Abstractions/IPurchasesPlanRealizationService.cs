namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с реализацией плана закупок
    /// </summary>
    public interface IPurchasesPlanRealizationService
    {
        /// <summary>
        /// Добавление записи о реализации товара
        /// </summary>
        /// <returns></returns>
        void AddPurchasesPlanRealizations(InvoicePosition invoicePosition);
    }
}
