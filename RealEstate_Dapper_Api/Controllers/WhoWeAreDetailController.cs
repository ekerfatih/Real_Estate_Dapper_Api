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
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto) {
            await _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("WhoWeAreDetail başarılı bir şekilde eklendi");
        }

        [HttpDelete("DeleteWhoWeAre/{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id) {
            await _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("WhoWeAreDetail başarıyla silindi");
        }

        [HttpPut("UpdateWhoWeAre")]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto) {
            await _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("WhoWeAreDetail Başarıyla Güncellendi");
        }

        [HttpGet("GetByIdWhoWeAre/{id}")]
        public async Task<IActionResult> GetWhoWeAreDetailById(int id) {
            return Ok(await _whoWeAreRepository.GetWhoWeAreDetailById(id));
        }
    }
}

