using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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
            var values = await _productRepository.GetLast5RentedProduct();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeByTrue/{id}")]
        public async Task<IActionResult> GetProductAdvertsListByEmployeeIdByTrue(int id) {
            var values = await _productRepository.GetProductAdvertListByEmployeeByTrue(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByFalse/{id}")]
        public async Task<IActionResult> GetProductAdvertsListByEmployeeIdByFalse(int id) {
            var values = await _productRepository.GetProductAdvertListByEmployeeByFalse(id);
            return Ok(values);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto) {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan Başarıyla Eklendi");
        }
        [HttpGet("GetProductByProductId/{id}")]
        public async Task<IActionResult> GetProductByProductId(int id) {
            var value = await _productRepository.GetProductByProductId(id);
            return Ok(value);
        }
        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city) {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory() {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategory();
            return Ok(values);
        }
        [HttpGet("GetLast3RentedProduct")]
        public async Task<IActionResult> GetLast3RentedProduct() {
            var values = await _productRepository.GetLast3RentedProduct();
            return Ok(values);
        }
    }
}
