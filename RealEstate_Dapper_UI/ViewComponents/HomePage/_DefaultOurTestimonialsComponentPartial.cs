using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage {
    public class _DefaultOurTestimonialsComponentPartial : ViewComponent {

        readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurTestimonialsComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/Testimonial/TestimonialList");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
