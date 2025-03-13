using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageController(IProductImageRepository productImageRepository) {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("GetProductImageById")]
        public async Task<IActionResult> GetProductImageById(int id) {
            var value = await _productImageRepository.GetProductImageListByProductId(id);
            return Ok(value);
        }
    }
}
