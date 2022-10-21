namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

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

    }
}
