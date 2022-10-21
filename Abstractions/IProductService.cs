namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;

    /// <summary>
    /// Интерфейс сервиса работы с товарами
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDTO> GetProducts();

    }
}
