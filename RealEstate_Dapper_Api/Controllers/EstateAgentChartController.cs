using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EstateAgentChartController : ControllerBase {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository) {
            _chartRepository = chartRepository;
        }

        [HttpGet("Get5CityForChart")]
        public async Task<IActionResult> Get5CityForChart() {
            var values = await _chartRepository.Get5CityForChart();
            return Ok(values);
        }
    }
}
