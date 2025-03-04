using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs;

public class SignalRHub(IHttpClientFactory httpClientFactory) : Hub {

    private readonly IHttpClientFactory _httpHttpClientFactory = httpClientFactory;

    public async Task SendCategoryCount() {
        #region CategoryCount

        var client = _httpHttpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Statistics/CategoryCount");
        var value = await responseMessage.Content.ReadAsStringAsync();
        await Clients.All.SendAsync("ReceiveCategoryCount", value);

        #endregion
    }


}

