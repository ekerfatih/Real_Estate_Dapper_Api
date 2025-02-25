using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers;

public class StatisticsController(IHttpClientFactory httpClientFactory) : Controller {
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<IActionResult> Index() {
        #region activeCategoryCount

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Statistics/ActiveCategoryCount");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        ViewBag.activeCategoryCount = jsonData;

        #endregion
        #region activeEmployeeCount

        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("http://localhost:5225/api/Statistics/ActiveEmployeeCount");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.activeEmployeeCount = jsonData2;

        #endregion
        #region ApartmentCount

        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("http://localhost:5225/api/Statistics/ApartmentCount");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.apartmentCount = jsonData3;

        #endregion
        #region AveragePriceByRent

        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("http://localhost:5225/api/Statistics/AveragePriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        var value = decimal.Parse(jsonData4);
        ViewBag.averagePriceByRent = value.ToString("c", new CultureInfo("tr-TR"));


        #endregion
        #region AveragePriceBySale

        var client5 = _httpClientFactory.CreateClient();
        var responseMessage5 = await client5.GetAsync("http://localhost:5225/api/Statistics/AveragePriceBySale");
        var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
        decimal price = decimal.Parse(jsonData5);
        ViewBag.averagePriceBySale = price.ToString("c", new CultureInfo("tr-TR"));



        #endregion
        #region AverageRoomCount

        var client6 = _httpClientFactory.CreateClient();
        var responseMessage6 = await client6.GetAsync("http://localhost:5225/api/Statistics/AverageRoomCount");
        var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
        ViewBag.averageRoomCount = jsonData6;

        #endregion
        #region CategoryCount

        var client7 = _httpClientFactory.CreateClient();
        var responseMessage7 = await client7.GetAsync("http://localhost:5225/api/Statistics/CategoryCount");
        var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
        ViewBag.categoryCount = jsonData7;

        #endregion
        #region CategoryNameByMaxProductCount

        var client8 = _httpClientFactory.CreateClient();
        var responseMessage8 = await client8.GetAsync("http://localhost:5225/api/Statistics/CategoryNameByMaxProductCount");
        var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
        ViewBag.ctegoryNameByMaxProductCount = jsonData8;

        #endregion
        #region EmployeeNameByMaxProductCount

        var client9 = _httpClientFactory.CreateClient();
        var responseMessage9 = await client9.GetAsync("http://localhost:5225/api/Statistics/EmployeeNameByMaxProductCount");
        var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
        ViewBag.employeeNameByMaxProductCount = jsonData9;

        #endregion
        #region CityNameByMaxProductCount

        var client10 = _httpClientFactory.CreateClient();
        var responseMessage10 = await client10.GetAsync("http://localhost:5225/api/Statistics/CityNameByMaxProductCount");
        var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
        ViewBag.cityNameByMaxProductCount = jsonData10;

        #endregion
        #region DifferentCityCount

        var client11 = _httpClientFactory.CreateClient();
        var responseMessage11 = await client11.GetAsync("http://localhost:5225/api/Statistics/DifferentCityCount");
        var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonData11;

        #endregion
        #region PassiveCategoryCount

        var client12 = _httpClientFactory.CreateClient();
        var responseMessage12 = await client12.GetAsync("http://localhost:5225/api/Statistics/PassiveCategoryCount");
        var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
        ViewBag.passiveCategoryCount = jsonData12;

        #endregion
        #region ProductCount

        var client13 = _httpClientFactory.CreateClient();
        var responseMessage13 = await client13.GetAsync("http://localhost:5225/api/Statistics/ProductCount");
        var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonData13;

        #endregion
        #region LastProductPrice

        var client14 = _httpClientFactory.CreateClient();
        var responseMessage14 = await client14.GetAsync("http://localhost:5225/api/Statistics/LastProductPrice");
        var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
        var value2 = decimal.Parse(jsonData14);
        ViewBag.lastProductPrice = value2.ToString("c", new CultureInfo("tr-TR"));

        #endregion
        #region NewestBuildingYear

        var client15 = _httpClientFactory.CreateClient();
        var responseMessage15 = await client15.GetAsync("http://localhost:5225/api/Statistics/NewestBuildingYear");
        var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
        ViewBag.newestBuildingYear = jsonData15;

        #endregion
        #region OldestBuildingYear

        var client16 = _httpClientFactory.CreateClient();
        var responseMessage16 = await client16.GetAsync("http://localhost:5225/api/Statistics/OldestBuildingYear");
        var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
        ViewBag.oldestBuildingYear = jsonData16;

        #endregion

        return View();
    }
}
