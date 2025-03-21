using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository {
    public interface IEmployeeRepository {
        Task<List<ResultEmployeeDto>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIdEmployeeDto> GetEmployeeById(int id);
    }
}
