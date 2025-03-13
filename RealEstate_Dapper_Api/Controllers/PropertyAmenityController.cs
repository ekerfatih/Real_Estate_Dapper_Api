using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenityController(IPropertyAmenityRepository propertyAmenityRepository) : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository = propertyAmenityRepository;


        [HttpGet("ResultPropertyAmenityByStatusTrue")]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id) {
            var values = await _propertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}
