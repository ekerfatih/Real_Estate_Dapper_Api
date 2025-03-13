using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeatureController(ISubFeatureRepository subFeatureRepository) {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet("GetAllSubFeature")]
        public async Task<IActionResult> GetAllSubFeature() {
            var values = await _subFeatureRepository.GetAllSubFeature();
            return Ok(values);
        }
    }
}
