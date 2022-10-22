namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;
    using Models;

    public class ProductService : IProductService
    {
        private readonly ApplicationContext _db;

        public ProductService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<ProductDTO> GetProducts()
        {
            return _db.Products
                .Include(p => p.Unit)
                .Select(x => new ProductDTO(x));
        }

        /// <inheritdoc/>
        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
    }

}
