using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ContactDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardLast4ContactListComponentPartial(IHttpClientFactory httpClientFactory) : ViewComponent {

    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<IViewComponentResult> InvokeAsync() {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5225/api/Contact/GetLast4Contacts");
        if (response.IsSuccessStatusCode) {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Last4ContactResultDto>>(jsonData);
            return View(values);
        }
        return View();
    }

}
