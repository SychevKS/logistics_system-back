namespace logistics_system_back.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Abstractions;
    using Models;

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

        [Authorize]
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [Authorize]
        [HttpGet("products/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            return Ok(_productService.GetProduct(id));
        }

        [Authorize]
        [HttpPut("products")]
        public void UpdateProduct([FromQuery] Product product)
        {
            _productService.UpdateProduct(product);
        }

        [Authorize]
        [HttpPost("products")]
        public void AddProduct([FromQuery] Product product)
        {
            _productService.AddProduct(product);
        }

        [Authorize]
        [HttpDelete("products")]
        public void RemoveProduct(Guid productId)
        {
            _productService.RemoveProduct(productId);
        }
    }
}
