using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository) {
            _serviceRepository = serviceRepository;
        }

        [HttpGet("GetServiceList")]
        public async Task<IActionResult> ServiceList() {
            var values = await _serviceRepository.GetAllServices();
            return Ok(values);
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto) {
            await _serviceRepository.CreateService(createServiceDto);
            return Ok("Servis başarılı bir şekilde eklendi");
        }

        [HttpDelete("DeleteService")]
        public async Task<IActionResult> DeleteService(int id) {
            await _serviceRepository.DeleteService(id);
            return Ok("Servis başarıyla silindi");
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto) {
            await _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Servis Başarıyla Güncellendi");
        }

        [HttpGet("GetServiceById/{id}")]
        public async Task<IActionResult> GetServiceById(int id) {
            return Ok(await _serviceRepository.GetServiceById(id));
        }
    }
}
