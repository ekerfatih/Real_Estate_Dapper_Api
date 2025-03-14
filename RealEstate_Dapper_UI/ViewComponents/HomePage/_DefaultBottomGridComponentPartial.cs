using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage {
    public class _DefaultBottomGridComponentPartial : ViewComponent {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBottomGridComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/BottomGrid/GetBottomGridList");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
