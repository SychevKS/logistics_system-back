namespace logistics_system_back.Abstractions
{
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с остатками
    /// </summary>
    public interface IRemainingService
    {
        /// <summary>
        /// Добавление записи о остатке товара
        /// </summary>
        /// <returns></returns>
        void AddRemains(InvoicePosition invoicePosition);

    }
}
