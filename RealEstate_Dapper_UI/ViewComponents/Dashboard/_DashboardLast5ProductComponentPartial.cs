using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardLast5ProductComponentPartial : ViewComponent {
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Products/GetLast5RentedProducts");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLats5RentProductWithCategoryDtos>>(jsonData);
            return View(values);
        }

        return View();
    }
}
