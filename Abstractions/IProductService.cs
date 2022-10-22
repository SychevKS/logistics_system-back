namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

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

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

    }
}
