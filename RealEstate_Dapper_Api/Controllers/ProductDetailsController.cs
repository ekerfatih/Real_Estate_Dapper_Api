using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase {
        private readonly IProductRepository _productRepository;

        public ProductDetailsController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(int id) {
            var value = await _productRepository.GetProductDetailByProductId(id);
            return Ok(value);
        }
    }
}
