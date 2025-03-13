using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent {
    public class _EstateAgentLast5ProductComponentPartial : ViewComponent {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService) {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var id = _loginService.GetUserId;
            var responseMessage = await client.GetAsync("http://localhost:5225/api/EstateAgentLastProducts/GetLast5ProductsByEmployee?id=" + id);
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLats5RentProductWithCategoryDtos>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
