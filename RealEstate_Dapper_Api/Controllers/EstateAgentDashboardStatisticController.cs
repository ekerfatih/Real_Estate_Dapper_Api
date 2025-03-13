using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EstateAgentDashboardStatisticController : ControllerBase {
        private IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository) {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("AllProductCount")]
        public async Task<IActionResult> AllProductCount() {
            return Ok(await _statisticRepository.AllProductCount());
        }

        [HttpGet("ProductCountByEmployeeId")]
        public async Task<IActionResult> ProductCountByEmployeeId(int id) {
            return Ok(await _statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public async Task<IActionResult> ProductCountByStatusFalse(int id) {
            return Ok(await _statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public async Task<IActionResult> ProductCountByStatusTrue(int id) {
            return Ok(await _statisticRepository.ProductCountByStatusTrue(id));
        }
    }
}
