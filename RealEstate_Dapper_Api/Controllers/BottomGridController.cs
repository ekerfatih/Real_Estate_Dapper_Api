using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BottomGridController : ControllerBase {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository) {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet("GetBottomGridList")]
        public async Task<IActionResult> BottomGridList() {
            var values = await _bottomGridRepository.GetAllBottomGrids();
            return Ok(values);
        }

        [HttpPost("CreateBottomGrid")]
        public IActionResult CreateBottomGrid(CreateBottomGridDto createBottomGridDto) {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("BottomGrid Başarıyla Oluşturuldu");
        }

        [HttpPut("UpdateBottomGrid")]
        public IActionResult UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto) {
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("BottomGrid Başarıyla Güncellendi");
        }

        [HttpDelete("DeleteBottomGrid/{id}")]

        public IActionResult DeleteBottomGrid(int id) {
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok();
        }
        [HttpGet("GetBottomGridById/{id}")]
        public async Task<IActionResult> GetByIdBottomGrid(int id) {
            var bottomGridValue = await _bottomGridRepository.GetByIdBottomGrid(id);
            return Ok(bottomGridValue);
        }

    }
}
