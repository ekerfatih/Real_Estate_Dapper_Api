using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ContactController(IContactRepository contactRepository) : ControllerBase {

    private readonly IContactRepository _contactRepository = contactRepository;


    [HttpGet("GetLast4Contacts")]
    public async Task<IActionResult> GetLast4Contacts() {
        var values = await _contactRepository.GetLast4Contact();
        return Ok(values);
    }



}
