using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EstateAgentLastProductsController : ControllerBase {
        private readonly ILast5ProductRepository _last5ProductRepository;

        public EstateAgentLastProductsController(ILast5ProductRepository last5ProductRepository) {
            _last5ProductRepository = last5ProductRepository;
        }

        [HttpGet("GetLast5ProductsByEmployee")]
        public async Task<IActionResult> GetLast5ProductsByEmployee(int id) {
            var values = await _last5ProductRepository.GetLast5RentedProduct(id);
            return Ok(values);
        }
    }
}
