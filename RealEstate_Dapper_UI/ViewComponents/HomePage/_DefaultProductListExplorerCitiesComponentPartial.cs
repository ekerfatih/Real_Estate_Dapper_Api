using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage {
    public class _DefaultProductListExplorerCitiesComponentPartial : ViewComponent {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExplorerCitiesComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/PopularLocation/GetPopularLocationList");
            if(responseMessage.IsSuccessStatusCode){
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultPopularPlaceDtos>>(jsonData);
                return View(result);
            }
            return View();
        }
    }
}
