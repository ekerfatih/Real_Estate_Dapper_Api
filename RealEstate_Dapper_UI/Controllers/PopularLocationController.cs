using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_UI.Controllers;

public class PopularLocationController : Controller {
    private readonly IHttpClientFactory _httpClientFactory;

    public PopularLocationController(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index() {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/PopularLocation/GetPopularLocationList");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultPopularPlaceDtos>>(jsonData);
            return View(result);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreatePopularLocation() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDtos createPopularLocationDto) {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage =
            await client.PostAsync("http://localhost:5225/api/PopularLocation/CreatePopularLocation", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> DeletePopularLocation(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =
            await client.DeleteAsync($"http://localhost:5225/api/PopularLocation/DeletePopularLocation/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePopularLocation(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =
            await client.GetAsync($"http://localhost:5225/api/PopularLocation/GetPopularLocationById/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdatePopularLocationDtos>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDtos updatePopularLocationDto) {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("http://localhost:5225/api/PopularLocation/UpdatePopularLocation",
            stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }
}
