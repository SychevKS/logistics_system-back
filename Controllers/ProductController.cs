namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Abstractions;

    /// <summary>
    /// Контролер товаров
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("products")]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

    }
}
