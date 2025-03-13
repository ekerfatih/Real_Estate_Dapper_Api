using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentChartDtos;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent {
    public class _EstateAgentDashboardChartComponentPartial : ViewComponent {

        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/EstateAgentChart/Get5CityForChart");
            if(responseMessage.IsSuccessStatusCode){
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
