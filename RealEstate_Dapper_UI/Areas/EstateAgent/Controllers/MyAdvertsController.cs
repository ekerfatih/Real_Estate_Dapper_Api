using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers;
[Area("EstateAgent")]
public class MyAdvertsController : Controller {

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService) {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    public async Task<IActionResult> ActiveAdverts() {
        var id = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Products/ProductAdvertsListByEmployeeByTrue/" + id);
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> PassiveAdverts() {
        var id = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Products/ProductAdvertsListByEmployeeByFalse/" + id);
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateAdvert() {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Categories/ListCategory");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.SelectListItems = categoryValues;
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto) {
        createProductDto.DealOfTheDay = false;
        createProductDto.AdvertisementDate = DateTime.Now;
        createProductDto.ProductStatus = true;
        var id = _loginService.GetUserId;
        createProductDto.EmployeeId = int.Parse(id);
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5225/api/Products/CreateProduct", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("ActiveAdverts","MyAdverts");
        }
        return View();
    }
}
