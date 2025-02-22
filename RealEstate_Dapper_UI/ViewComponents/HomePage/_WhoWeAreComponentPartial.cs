using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage {
    public class _WhoWeAreComponentPartial : ViewComponent {

        private IHttpClientFactory _httpClientFactory;

        public _WhoWeAreComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/WhoWeAreDetail/GetWhoWeAreList");
            var responseMessage2 = await client2.GetAsync("http://localhost:5225/api/Service/GetServiceList");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
                ViewBag.Title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.Subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}
