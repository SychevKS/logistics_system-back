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
        /// Получение товара
        /// </summary>
        /// <returns></returns>
        ProductDTO? GetProduct(Guid productId);

        /// <summary>
        /// Обновление товара
        /// </summary>
        /// <param name="product"></param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

        /// <summary>
        /// Удаление товара
        /// </summary>
        void RemoveProduct(Guid productId);

    }
}
