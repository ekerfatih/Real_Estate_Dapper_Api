using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController(IStatisticsRepository statisticsRepository) : ControllerBase {
        private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;

        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount() {
            return Ok(await _statisticsRepository.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]
        public async Task<IActionResult> ActiveEmployeeCount() {
            return Ok(await _statisticsRepository.ActiveEmployeeCount());
        }

        [HttpGet("ApartmentCount")]
        public async Task<IActionResult> ApartmentCount() {
            return Ok(await _statisticsRepository.ApartmentCount());
        }

        [HttpGet("AveragePriceByRent")]
        public async Task<IActionResult> AveragePriceByRent() {
            return Ok(await _statisticsRepository.AverageProductPriceByRent());
        }

        [HttpGet("AveragePriceBySale")]
        public async Task<IActionResult> AveragePriceBySale() {
            return Ok(await _statisticsRepository.AverageProductPriceBySale());
        }

        [HttpGet("AverageRoomCount")]
        public async Task<IActionResult> AverageRoomCount() {
            return Ok(await _statisticsRepository.AverageRoomCount());
        }

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount() {
            return Ok(await _statisticsRepository.CategoryCount());
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public async Task<IActionResult> CategoryNameByMaxProductCount() {
            return Ok(await _statisticsRepository.CategoryNameByMaxProductCount());
        }

        [HttpGet("EmployeeNameByMaxProductCount")]
        public async Task<IActionResult> EmployeeNameByMaxProductCount() {
            return Ok(await _statisticsRepository.EmployeeNameByMaxProductCount());
        }

        [HttpGet("CityNameByMaxProductCount")]
        public async Task<IActionResult> CityNameByMaxProductCount() {
            return Ok(await _statisticsRepository.CityNameByMaxProductCount());
        }

        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount() {
            return Ok(await _statisticsRepository.DifferentCityCount());
        }

        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount() {
            return Ok(await _statisticsRepository.PassiveCategoryCount());
        }

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount() {
            return Ok(await _statisticsRepository.ProductCount());
        }

        [HttpGet("LastProductPrice")]
        public async Task<IActionResult> LastProductPrice() {
            return Ok(await _statisticsRepository.LastProductPrice());
        }

        [HttpGet("NewestBuildingYear")]
        public async Task<IActionResult> NewestBuildingYear() {
            return Ok(await _statisticsRepository.NewestBuildingYear());
        }

        [HttpGet("OldestBuildingYear")]
        public async Task<IActionResult> OldestBuildingYear() {
            return Ok(await _statisticsRepository.OldestBuildingYear());
        }
    }
}
