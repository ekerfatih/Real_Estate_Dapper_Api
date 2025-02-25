﻿using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;

namespace RealEstate_Dapper_UI.Controllers;

public class ServiceController : Controller {
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index() {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5225/api/Service/GetServiceList");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            return View(result);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateService() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto) {
        createServiceDto.ServiceStatus = true;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createServiceDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage =
            await client.PostAsync("http://localhost:5225/api/Service/CreateService", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }

        return View();
    }
    [HttpGet]
    public async Task<IActionResult> DeleteService(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:5225/api/Service/DeleteService/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateService(int id) {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5225/api/Service/GetServiceById/{id}");
        if (responseMessage.IsSuccessStatusCode) {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto) {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateServiceDto);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("http://localhost:5225/api/Service/UpdateService", stringContent);
        if (responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View();
    }
}
