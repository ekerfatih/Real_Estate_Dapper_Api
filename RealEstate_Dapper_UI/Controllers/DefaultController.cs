using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_UI.Controllers {
    public class DefaultController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;

        }


        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient("MyClient");
            var responseMessage = await client.GetAsync("Categories/ListCategory");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                return View(categoryValues);
            }
            return View(new List<SelectListItem>());
        }
        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, string propertyCategoryId, string city) {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["propertyCategoryId"] = propertyCategoryId;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }

    }
}
