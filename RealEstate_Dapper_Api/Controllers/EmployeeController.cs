using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("ListEmployee")]
        public async Task<IActionResult> EmployeeList() {
            var values = await _employeeRepository.GetAllEmployee();
            return Ok(values);
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto) {
            await _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Employee başarılı bir şekilde eklendi");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id) {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("Employee başarıyla silindi");
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto) {
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Employee Başarıyla Güncellendi");
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id) {
            return Ok(await _employeeRepository.GetEmployeeById(id));
        }
    }
}
