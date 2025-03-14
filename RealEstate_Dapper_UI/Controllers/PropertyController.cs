using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Globalization;

namespace RealEstate_Dapper_UI.Controllers {
    public class PropertyController : Controller {

        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5225/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city) {
            searchKeyValue = TempData["searchKeyValue"].ToString().ToLower();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString().ToLower());
            city = TempData["city"].ToString().ToLower();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5225/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug,int id) {
            ViewBag.id = id;
            var client = _httpClientFactory.CreateClient("MyClient");

            var responseMessage = await client.GetAsync("Products/GetProductByProductId/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetProductByProductIdDto>(jsonData);

            var responseMessage2 = await client.GetAsync("ProductDetails/GetProductDetailByProductId/" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

            ViewBag.title1 = values.Title.ToString() ?? "Bura Hatalı";
            ViewBag.price = values.Price.ToString("c", new CultureInfo("tr-TR"));
            ViewBag.city = values.City;
            ViewBag.district = values.District;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.address = values.Address;
            ViewBag.description = values.Description;
            ViewBag.productId = values.ProductId;
            ViewBag.userId = values.AppUserId;

            ViewBag.bathCount = values2.BathCount;

            TimeSpan t = (DateTime.Now - values.AdvertisementDate);
            int days = t.Days;
            ViewBag.dateDiff = days / 30;
            ViewBag.bedCount = values2.BedRoomCount;
            ViewBag.productSize = values2.ProductSize;
            ViewBag.roomCount = values2.RoomCount;
            ViewBag.garageCount = values2.GarageSize;
            ViewBag.date = values.AdvertisementDate;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location = values2.Location;
            ViewBag.videoUrl = values2.VideoUrl;

            string slugFromTitle = CreateSlug(values.Title);
            ViewBag.slugUrl = slugFromTitle;

            return View();

        }
        private string CreateSlug(string title) {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "-");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9]", "");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^\s+]"," ").Trim();
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^\s]","-");
            return title;
        }

    }
}
