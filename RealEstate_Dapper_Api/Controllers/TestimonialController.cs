using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase {

        ITestimonialRepository _testimonialRepository;

        public TestimonialController(ITestimonialRepository testimonialRepository) {
            _testimonialRepository = testimonialRepository;
        }

        [HttpGet("TestimonialList")]
        public async Task<IActionResult> TestimonialList() {
            var values = await _testimonialRepository.GetAllTestimonialsAsync();
            return Ok(values);
        }

    }
}
