using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.Controllers;

public class WhoWeAreController : Controller {
    private readonly IHttpClientFactory _httpClientFactory;

    public WhoWeAreController(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index() {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/WhoWeAreDetail/GetWhoWeAreList");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
            return View(result);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateWhoWeAre() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDetailDto createWhoWeAreDetailDto) {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createWhoWeAreDetailDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage =
            await client.PostAsync("http://localhost:5225/api/WhoWeAreDetail/CreateWhoWeAre", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }

        return View();
    }
    [HttpGet]
    public async Task<IActionResult> DeleteWhoWeAre(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:5225/api/WhoWeAreDetail/DeleteWhoWeAre/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateWhoWeAre(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5225/api/WhoWeAreDetail/GetByIdWhoWeAre/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateWhoWeAreDetailDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDetailDto updateWhoWeAreDto) {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateWhoWeAreDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("http://localhost:5225/api/WhoWeAreDetail/UpdateWhoWeAre", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }
}
