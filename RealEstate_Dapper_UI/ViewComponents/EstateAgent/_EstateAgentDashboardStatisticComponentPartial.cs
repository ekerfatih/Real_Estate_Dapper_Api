using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent {
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService = null) {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var id = _loginService.GetUserId;
            #region AllProductCount

            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync($"http://localhost:5225/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.allProductCount = jsonData13;

            #endregion
            #region ProductCountByEmployeeId

            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync($"http://localhost:5225/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+id);
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeId = jsonData9;

            #endregion
            #region ProductCountByStatusFalse

            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync($"http://localhost:5225/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.productCountByStatusFalse = jsonData11;

            #endregion
            #region ProductCountByStatusTrue

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:5225/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByStatusTrue = jsonData4;


            #endregion


            return View();
        }
    }
}
