namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;

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
                .Include(p => p.PriceList)
                .Select(x => new ProductDTO(x));
        }
    }
    
}
