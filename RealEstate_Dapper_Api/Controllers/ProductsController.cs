using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductList")]
        public async Task<IActionResult> ProductList() {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory() {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

    }
}
