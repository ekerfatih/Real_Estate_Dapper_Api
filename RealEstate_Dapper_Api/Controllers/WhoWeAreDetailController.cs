using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase {

        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository) {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet("GetWhoWeAreList")]
        public async Task<IActionResult> WhoWeAreDetailList() {
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetail();
            return Ok(values);
        }

        [HttpPost("CreateWhoWeAre")]
        public IActionResult CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto) {
            _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("WhoWeAreDetail başarılı bir şekilde eklendi");
        }

        [HttpDelete("DeleteWhoWeAre/{id}")]
        public IActionResult DeleteWhoWeAreDetail(int id) {
            _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("WhoWeAreDetail başarıyla silindi");
        }

        [HttpPut("UpdateWhoWeAre")]
        public IActionResult UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto) {
            _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("WhoWeAreDetail Başarıyla Güncellendi");
        }

        [HttpGet("GetByIdWhoWeAre/{id}")]
        public async Task<IActionResult> GetWhoWeAreDetailById(int id) {
            return Ok(await _whoWeAreRepository.GetWhoWeAreDetailById(id));
        }
    }
}

