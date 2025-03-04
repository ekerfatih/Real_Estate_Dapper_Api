using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationsRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PopularLocationController : ControllerBase {

        private readonly IPopularLocationsRepository _popularLocationRepository;

        public PopularLocationController(IPopularLocationsRepository popularLocationRepository) {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet("GetPopularLocationList")]
        public async Task<IActionResult> GetPopularLocationList() {
            var values = await _popularLocationRepository.PopularLocationsList();
            return Ok(values);
        }

        [HttpDelete("DeletePopularLocation/{id}")]
        public IActionResult DeletePopularLocation(int id) {
            _popularLocationRepository.DeletePopularLocation(id);
            return Ok("popularLocationBaşarıyla silindi");
        }

        [HttpPut("UpdatePopularLocation")]
        public IActionResult UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto) {
            _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("popularLocation Başarıyla güncellendi");
        }

        [HttpPost("CreatePopularLocation")]
        public IActionResult CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto) {
            _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("PopularLocation Başarıyla oluşturuldu");
        }

        [HttpGet("GetPopularLocationById/{id}")]
        public async Task<IActionResult> GetPopularLocationById(int id) {
            var values = await _popularLocationRepository.GetByIdPopularLocation(id);
            return Ok(values);
        }

    }
}
