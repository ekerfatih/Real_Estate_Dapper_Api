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
            var values = await _productRepository.GetAllProduct();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory() {
            var values = await _productRepository.GetAllProductWithCategory();
            return Ok(values);
        }

        [HttpGet("UpdateDealOfTheDayStatus/{id}")]
        public IActionResult UpdateDealOfTheDayStatus(int id) {
             _productRepository.UpdateDealOfTheDayStatus(id);
             return Ok("oki");
        }

        [HttpGet("GetLast5RentedProducts")]
        public async Task<IActionResult> GetLast5RentedProducts() {
            var values =  await _productRepository.GetLast5RentedProduct();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployee/{id}")]
        public async Task<IActionResult> GetProductAdvertsListByEmployeeId(int id) {
            var values = await _productRepository.GetProductAdvertListByEmployee(id);
            return Ok(values);
        }

    }
}
