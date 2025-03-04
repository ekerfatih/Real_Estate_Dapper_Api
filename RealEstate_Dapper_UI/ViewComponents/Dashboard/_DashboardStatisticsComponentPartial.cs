using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory) : ViewComponent {
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    public async Task<IViewComponentResult> InvokeAsync() {
        #region ProductCount

        var client13 = _httpClientFactory.CreateClient();
        var responseMessage13 = await client13.GetAsync("http://localhost:5225/api/Statistics/ProductCount");
        var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonData13;

        #endregion
        #region EmployeeNameByMaxProductCount

        var client9 = _httpClientFactory.CreateClient();
        var responseMessage9 = await client9.GetAsync("http://localhost:5225/api/Statistics/EmployeeNameByMaxProductCount");
        var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
        ViewBag.employeeNameByMaxProductCount = jsonData9;

        #endregion
        #region DifferentCityCount

        var client11 = _httpClientFactory.CreateClient();
        var responseMessage11 = await client11.GetAsync("http://localhost:5225/api/Statistics/DifferentCityCount");
        var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonData11;

        #endregion
        #region AveragePriceByRent

        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("http://localhost:5225/api/Statistics/AveragePriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        var value = decimal.Parse(jsonData4);
        ViewBag.averagePriceByRent = value.ToString("c", new CultureInfo("tr-TR"));


        #endregion


        return View();
    }
}
