using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ToDoListController(IToDoListRepository toDoListRepository) : ControllerBase {

    private readonly IToDoListRepository _toDoListRepository = toDoListRepository;

    [HttpGet("GetToDoList")]
    public async Task<IActionResult> GetToDoList() {
        var values = await _toDoListRepository.GetAllToDoList();
        return Ok(values);
    }
}
